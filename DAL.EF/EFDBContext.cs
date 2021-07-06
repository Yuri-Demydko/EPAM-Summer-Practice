
using Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace EFDAO 
{
    public sealed class EFDBContext : IdentityDbContext<EUser>
    {
        public DbSet<EUser> Users { get; set; }
        public DbSet<EBook> Books { get; set; }
        public DbSet<EFavoriteBooksToUsers> FavoriteBooksToUsers { get; set; }


        public EFDBContext() : base()
        {
            Database.EnsureCreated();
        }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
               // .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EPAM.Library.DB;Trusted_Connection=True;AttachDbFileName=D:\\SQL_SERVER\\EPAM.DB\\EPAM.Library.DB");//<-work connection
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EPAM.Library.DB;Trusted_Connection=True;");//<-home connection
                /*.UseSqlServer(
                    "Server=tcp:sql-server-210706122930.database.windows.net,1433;" +
                    "Initial Catalog=sql_210706122930_db;" +
                    "Persist Security Info=False;" +
                    "User ID=lsdamnit;" +
                    "Password=Demydko992233;" +
                    "MultipleActiveResultSets=False;" +
                    "Encrypt=True;TrustServerCertificate=False;" +
                    "Connection Timeout=30;");*/ //<-- Azure connection
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EFavoriteBooksToUsers>()
                .HasKey(fbtu=>new {fbtu.BookId, fbtu.UserId });
            modelBuilder.Entity<EUser>()
                .HasMany(u => u.OwnBooks)
                .WithOne(b => b.Owner);
        }
        
        
    }
}