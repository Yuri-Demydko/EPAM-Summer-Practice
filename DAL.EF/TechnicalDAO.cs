using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities.Entities;

namespace DAL.EF
{

    public class TechnicalDAO:ITechDAO
    {
        private readonly EFDBContext _context;
        private readonly IUsersDAO _usersDao;

        public TechnicalDAO(EFDBContext context, IUsersDAO usersDao)
        {
            _context = context;
            _usersDao = usersDao;
        }
        
        public async Task PrefillDatabaseWithTestDataAsync()
        {
            if (_context.Users.Any())
              return;
            EUser adm = new EUser()
            {
                UserName = "YDN",
                Email = "yd@fake-mail.com",
                FirstName = "Charlie",
                LastName = "Bob",
                DateOfBirth = "01-01-1970",
                City = "London",
                AdditionalInfo = "I am the king of that swamp!\nYO WILL BE BANNED IN\n3...\n2...\n1...\nLol. Nope. Just kidding. Let's be friends :3"
            };
            await _usersDao.AddUserAsync(adm, "Admin123_");
            IList<string> gradients = new List<string>()
            {
                "background: rgb(59,34,0); background: linear-gradient(180deg, rgba(59,34,0,1) 0%, rgba(163,96,3,1) 100%);",
                "background: rgb(2,0,36); background: linear-gradient(180deg, rgba(2,0,36,1) 0%, rgba(123,149,154,1) 100%)",
                "background: rgb(3,51,3); background: linear-gradient(180deg, rgba(3,51,3,1) 0%, rgba(0,166,0,1) 100%);",
                "background: rgb(51,3,3); background: linear-gradient(180deg, rgba(51,3,3,1) 0%, rgba(166,0,0,1) 100%);",
                "background: rgb(6,39,74); background: linear-gradient(180deg, rgba(6,39,74,1) 0%, rgba(132,119,255,1) 100%);",
                "background: rgb(0,72,85); background: linear-gradient(180deg, rgba(0,72,85,1) 0%, rgba(17,93,0,1) 100%);",
                "background: rgb(77,0,85); background: linear-gradient(180deg, rgba(77,0,85,1) 0%, rgba(87,21,21,1) 100%);",
            };
            for (int i = 0; i < 70; i++)
            {
                EBook book = new EBook()
                {
                    Author = "Bob Charlie",
                    Title = $"Breathtaking adventures of Example. Part №{i}",
                    Genre = "Fairytale",
                    Owner = adm,
                    CardBg = gradients[new Random().Next(7)],
                    Description =
                        "Hi! It is an example book page. Unfortunately it doesn't attached to a PDF file. So, you aren't able to read it. But don't worry, you still can" +
                        "find here some real books uploaded by real users and/or upload some by yourself.\n\nOh, and if you have nothing to do, you can try to collect all" +
                        "70 parts of that \"book\" in you favorites (of course you won't do it)."
                };
                 _context.Books.Add(book);
            }
            await _context.SaveChangesAsync();
        }
    }
}