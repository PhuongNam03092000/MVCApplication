using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure
{
    public class MVCApplicatonDbContext : IdentityDbContext<IdentityUser>
    {
        public MVCApplicatonDbContext(DbContextOptions<MVCApplicatonDbContext> options):base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
          
            builder.Entity<BookAuthor>().HasKey(pk => new { pk.bookId, pk.authorId });
            builder.Entity<BookAuthor>().HasOne(ba => ba.author)
                                        .WithMany(ba => ba.listBookAuthor);

            builder.Entity<BookCategory>().HasKey(pk => new { pk.bookId, pk.categoryId });
            builder.Entity<BookCategory>().HasOne(bc => bc.category)
                                        .WithMany(bc => bc.listBookCategory);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
