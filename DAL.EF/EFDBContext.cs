using System.Linq;
using DAO.Interfaces;
using DTO.Entities;
using Microsoft.EntityFrameworkCore;


namespace EFDAO 
{
    public class EFDBContext : DbContext
    {
        public DbSet<EUser> Users { get; set; }
        public DbSet<EBook> Books { get; set; }
        public DbSet<EUserProfile> UserProfiles { get; set; }
        
        
        public EFDBContext()
        {
            Database.EnsureCreated();
            //TEST
            Prefill(this);
        }
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EPAM.Library.DB;Trusted_Connection=True;");
        }

        public static void Prefill(EFDBContext context)
        {
            if(!context.Users.Any())
            {
                EUser zero = new EUser()
                {
                    Id = 0,
                };
                EBook b1 = new EBook()
                {
                    Id = 0,
                    FilePath = "TESTPATH",
                    Title = "War and Peace"
                };
                EUserProfile zerop = new EUserProfile()
                {
                    Name = "Bob",
                    Id = 0,
                    User = zero,
                    AdditionalInfo = "Hi, I'm Bob!"
                };
                context.Users.Add(zero);
                context.Books.Add(b1);
                context.UserProfiles.Add(zerop);

                 context.SaveChanges();
            }
        }
    }
}