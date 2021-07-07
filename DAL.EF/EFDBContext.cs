using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace DAL.EF 
{
    public class EFDBContext : IdentityDbContext<EUser>
    {
        public DbSet<EUser> Users { get; set; }
        public DbSet<EBook> Books { get; set; }
        public DbSet<EFavoriteBooksToUsers> FavoriteBooksToUsers { get; set; }
        public virtual  DbSet<ELog> Logs { get; set; }


        public EFDBContext() : base()
        {
            Database.EnsureCreated();
            
        }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conn = "";
            try
            {
                //CONN_CONFIG.json added to .gitignore. Use your own connection string!
                var parsedObj = JObject.Parse(File.ReadAllText(@"..\DAL.EF\CONN_CONFIG.json"));
                conn = parsedObj["CONN"]?["HOME"]?.ToString();
                
            }
            catch (Exception e)
            {
                throw new Exception("USE YOUR OWN DH CONNECTION STRING!");
            }
            optionsBuilder
                .UseSqlServer(conn);
               
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EFavoriteBooksToUsers>()
                .HasKey(fbtu=>new {fbtu.BookId, fbtu.UserId });
            modelBuilder.Entity<EUser>()
                .HasMany(u => u.OwnBooks)
                .WithOne(b => b.Owner);
            
            modelBuilder.Entity<ELog>().ToTable("Logs");
        }
        
        
    }
}