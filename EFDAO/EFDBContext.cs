using System.Threading.Tasks;
using DTO.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFDAO
{
    public class EFDBContext : DbContext
    {
        public DbSet<EFUser> Users { get; set; }
        public DbSet<EFBook> Books { get; set; }
        public DbSet<EFUserProfile> UserProfiles { get; set; }
        
        
        public EFDBContext()
        {
            Database.EnsureCreated();
        }
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EPAM.Library.DB;Trusted_Connection=True;");
        }

        public static async Task Prefill(EFDBContext context)
        {
            EFUser zero = new EFUser()
            {
                Id = 0,
            };
            EFBook b1 = new EFBook()
            {
                Id = 0,
                FilePath = "TESTPATH",
                Title = "War and Peace"
            };
            EFUserProfile zerop = new EFUserProfile()
            {
                Name = "Bob",
                Id = 0,
                User = zero,
                AdditionalInfo = "Hi, I'm Bob!"
            };
            context.Users.Add(zero);
            context.Books.Add(b1);
            context.UserProfiles.Add(zerop);

            await context.SaveChangesAsync();
        }
    }
}