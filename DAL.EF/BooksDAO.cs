using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class BooksDAO : Interfaces.IBooksDAO
    {
        private readonly EFDBContext _context;
        private readonly IUsersDAO _usersDao;

        public BooksDAO(EFDBContext context, IUsersDAO usersDao)
        {
            _context = context;
            _usersDao = usersDao;
        }
        
        //TECH METHOD
        //REMOVE BEFORE PUBLISHING
        private void PrefillDatabaseWithTestData()
        {
            EUser adm = new EUser()
            {
                UserName = "ADMIN",
                Email = "admin@admin-mail.com",
                FirstName = "Bob",
                LastName = "Charlie",
                DateOfBirth = "01-01-1970",
                City = "St. Petersburg",
                AdditionalInfo = "Ultimate first user in that f*cking swamp!\n FEAR ME!"
            };
             _usersDao.AddUserAsync(adm, "Admin0101_");
            IList<string> _gradients = new List<string>()
            {
                "background: rgb(59,34,0); background: linear-gradient(180deg, rgba(59,34,0,1) 0%, rgba(163,96,3,1) 100%);",
                "background: rgb(2,0,36); background: linear-gradient(180deg, rgba(2,0,36,1) 0%, rgba(123,149,154,1) 100%)",
                "background: rgb(3,51,3); background: linear-gradient(180deg, rgba(3,51,3,1) 0%, rgba(0,166,0,1) 100%);",
                "background: rgb(51,3,3); background: linear-gradient(180deg, rgba(51,3,3,1) 0%, rgba(166,0,0,1) 100%);",
                "background: rgb(6,39,74); background: linear-gradient(180deg, rgba(6,39,74,1) 0%, rgba(132,119,255,1) 100%);",
                "background: rgb(0,72,85); background: linear-gradient(180deg, rgba(0,72,85,1) 0%, rgba(17,93,0,1) 100%);",
                "background: rgb(77,0,85); background: linear-gradient(180deg, rgba(77,0,85,1) 0%, rgba(87,21,21,1) 100%);",
            };
            for (int i = 0; i < 20; i++)
            {
                EBook book = new EBook()
                {
                    Author = "Bob Charlie",
                    Title = $"How to prefill a database. Part №{i}",
                    Genre = "Tutorial",
                    Owner = adm,
                    CardBg = _gradients[new Random().Next(4)],
                    Description =
                        "Entity Framework is an open-source ORM framework for .NET applications supported by Microsoft. It enables developers to work with data using objects of domain specific classes without focusing on the underlying database tables and columns where this data is stored. With the Entity Framework, developers can work at a higher level of abstraction when they deal with data, and can create and maintain data-oriented applications with less code compared with traditional applications." +
                        "\nOfficial Definition: “Entity Framework is an object-relational mapper (O/RM) that enables .NET developers to work with a database using .NET objects. It eliminates the need for most of the data-access code that developers usually need to write.”"
                };
                 _context.Books.Add(book);
            }
            _context.SaveChanges();
        }
        //------
        
        public async Task DeleteBook(string bookId)
        {
            var book = await GetBookById(bookId,false);
            if (book == null)
                throw new ArgumentException("Book with given id doesn't exist"); 
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
        public async Task UploadBook(EBook book, string ownerUserName)
        {
            if (book == null)
                throw new ArgumentException("Book parameter can't be null");
            var user = await _usersDao.GetUserByUserNameAsync(ownerUserName);
            await _context.Books.AddAsync(book);
           await _context.SaveChangesAsync();
           await _context.Database.ExecuteSqlRawAsync("update [dbo].[Books]" +
                                                      $"set OwnerId='{user.Id}'" +
                                                      $"where Id={book.Id}");
           await _context.SaveChangesAsync();
        }
        public async Task EditBookData(EBook updatedBook)
        {
            if (updatedBook == null)
                throw new ArgumentException("Book parameter can't be null");
            var oldBook =await GetBookById(updatedBook.Id.ToString(), true);
            if(oldBook.Data!=null && oldBook.Data.Any())
            {
                updatedBook.Data = new byte[oldBook.Data.Length];
                oldBook.Data.CopyTo(updatedBook.Data, 0);
            }
            _context.Update(updatedBook);
            await _context.SaveChangesAsync();
        }
        public async Task<EBook> GetBookById(string id,bool includeHeavyData=true)
        {
            var res = new EBook(){Id=-1};
            if(!includeHeavyData)
             res  = await _context.Books
                .Include(b=>b.Owner)
                .Where(b => b.Id.ToString() == id)
                .Select(b => new EBook()
                {
                    Id=b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Genre = b.Genre,
                    LikesCount = b.LikesCount,
                    CardBg = b.CardBg,
                    Owner = b.Owner,
                    Description = b.Description
                }).FirstOrDefaultAsync();
            else
            {
                res = await _context.Books
                    .Include(b => b.Owner)
                    .Where(b => b.Id.ToString() == id)
                    .Select(b => new EBook()
                    {
                        Id = b.Id,
                        Title = b.Title,
                        Author = b.Author,
                        Genre = b.Genre,
                        LikesCount = b.LikesCount,
                        CardBg = b.CardBg,
                        Owner = b.Owner,
                        Data = b.Data,
                        Description = b.Description
                    }).FirstOrDefaultAsync();
                /*if (res != null)
                    res.Data = await (from bd
                            in _context.Books
                        where bd.Id == res.Id
                        select bd.Data).FirstOrDefaultAsync();*/
            }
            if (res.Id == -1)
                throw new ArgumentException("Book with such id doesn't exist");
            
            return res;
        }
        public async Task<IList<EBook>> GetBooksGallery()
        {
            //byte[] Data not included!
            var res  = await _context.Books
                .Select(b => new EBook()
                {
                    Id=b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Genre = b.Genre,
                    LikesCount = b.LikesCount,
                    CardBg = b.CardBg
                }).ToListAsync();
            return res;
        }
        public async Task<IList<EBook>> GetFilteredBooksGallery(Tuple<string,byte> searchParameters)
        {
            var booksBasicList  = await _context.Books
                .Select(b => new EBook()
                {
                    Id=b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Genre = b.Genre,
                    LikesCount = b.LikesCount,
                    CardBg = b.CardBg,
                    Description = b.Description
                }).ToListAsync();
            var result = new List<EBook>();
            if(searchParameters.Item2==1)
              result = booksBasicList.Where(b => !string.IsNullOrWhiteSpace(b.Title)&& b.Title.Contains(searchParameters.Item1,StringComparison.OrdinalIgnoreCase))
                .ToList();
            if(searchParameters.Item2==2)
                result = booksBasicList.Where(b =>!string.IsNullOrWhiteSpace(b.Author)&& b.Author.Contains(searchParameters.Item1,StringComparison.OrdinalIgnoreCase))
                    .ToList();
            if(searchParameters.Item2==3)
                result = booksBasicList.Where(b =>!string.IsNullOrWhiteSpace(b.Genre)&& b.Genre.Contains(searchParameters.Item1,StringComparison.OrdinalIgnoreCase))
                    .ToList();

            if (searchParameters.Item2 == 4)
            {
               // var list2 = await _context.Books.Select(b => new Tuple<int, string>(b.Id, b.Description)).ToListAsync();
               result = booksBasicList.Where(b =>!string.IsNullOrWhiteSpace(b.Description)&& b.Description.Contains(searchParameters.Item1,StringComparison.OrdinalIgnoreCase))
                   .ToList();
            }

            return result;
                //throw new ArgumentException("Invalid search parameters!");
        }
        public async Task UpdateBookInFavorites(int bookId, string userName,bool removingMode=false)
        {
            var book = await GetBookById(bookId.ToString(), false);
            if(book==null)
                throw new ArgumentException("Book with such id doesn't exist");
            var user = await _usersDao.GetUserByUserNameAsync(userName,false);
            if(!removingMode)
            {
                await _context.FavoriteBooksToUsers.AddAsync(new EFavoriteBooksToUsers()
                {
                    BookId = bookId,
                    UserId = user.Id
                });
                await _context.Database.ExecuteSqlRawAsync("update [dbo].[Books]" +
                                                           "set LikesCount=LikesCount+1" +
                                                           $"where Id={bookId}");
                //_context.Books.FromSqlRaw();

                // _context.Books.Update(book).Entity.LikesCount+=1;
            }
            else
            {
                _context.FavoriteBooksToUsers.Remove(
                    await (from fbtu
                            in _context.FavoriteBooksToUsers
                        where (fbtu.BookId == bookId && fbtu.UserId == user.Id)
                        select fbtu).FirstOrDefaultAsync());
               // book.LikesCount--;
              // _context.Books.Update(book).Entity.LikesCount-=1;
              await _context.Database.ExecuteSqlRawAsync("update [dbo].[Books]" +
                                                         "set LikesCount=LikesCount-1" +
                                                         $"where Id={bookId}");
            }
            
            await _context.SaveChangesAsync();
        }
    }
}