using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using NaturalSort.Extension;

namespace DAL.EF
{
    public class BooksDAO : IBooksDAO
    {
        private readonly EFDBContext _context;
        private readonly IUsersDAO _usersDao;

        public BooksDAO(EFDBContext context, IUsersDAO usersDao)
        {
            _context = context;
            _usersDao = usersDao;
        }
        public async Task<bool> CheckBookData(string id)
        {
            try
            {
                var res1 = await _context.Books
                    .Where(b => b.Id.ToString() == id && (b.Data == null || b.Data.Length == 0))
                    .FirstAsync();
            }
            catch (Exception)
            {
                return true;
            }
            return false;
        }
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
                                                      $"set OwnerId='{user.Id}' " +
                                                      $"where Id={book.Id}");
           await _context.SaveChangesAsync();
        }
        public async Task EditBookData(EBook updatedBook)
        {
            if (updatedBook == null)
                throw new ArgumentException("Book parameter can't be null");
            
            await _context.Database.ExecuteSqlRawAsync("update [dbo].[Books] " +
                                                       $"set Title=N'{updatedBook.Title}', Author=N'{updatedBook.Author}', Genre=N'{updatedBook.Genre}', Description=N'{updatedBook.Description}' " +
                                                       $"where Id={updatedBook.Id}");
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
                })
                .ToListAsync();
            return res.OrderBy(b=> b.Title,StringComparison.OrdinalIgnoreCase.WithNaturalSort()).ToList();
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
                result = booksBasicList.Where(b =>!string.IsNullOrWhiteSpace(b.Description)&& b.Description.Contains(searchParameters.Item1,StringComparison.OrdinalIgnoreCase))
                   .ToList();
            }
            return result.OrderBy(b=>b.Title,StringComparison.OrdinalIgnoreCase.WithNaturalSort()).ToList();
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
            }
            else
            {
                _context.FavoriteBooksToUsers.Remove(
                    await (from fbtu
                            in _context.FavoriteBooksToUsers
                        where (fbtu.BookId == bookId && fbtu.UserId == user.Id)
                        select fbtu).FirstOrDefaultAsync());
                await _context.Database.ExecuteSqlRawAsync("update [dbo].[Books]" +
                                                           "set LikesCount=LikesCount-1" +
                                                           $"where Id={bookId}");
            }
            await _context.SaveChangesAsync();
        }
    }
}