using System.Linq;
using DAO.Interfaces;
using DTO.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace EFDAO 
{
    public class EFDBContext : IdentityDbContext<EUser>
    {
        public DbSet<EUser> Users { get; set; }
        public DbSet<EBook> Books { get; set; }
        public DbSet<EFavoriteBooksToUsers> FavoriteBooksToUsers { get; set; }
        
        
        public EFDBContext() : base()
        {
            Database.EnsureCreated();
            //TEST
            
        }
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EPAM.Library.DB;Trusted_Connection=True;");
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