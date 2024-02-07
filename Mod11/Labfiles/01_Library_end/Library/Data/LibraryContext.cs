using Library.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class LibraryContext : IdentityDbContext
    {

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // set up some initial users
            var password = new PasswordHasher<IdentityUser>();
            var users = new List<IdentityUser>();
            var usernames = new List<string>() { "bill", "mary", "mike", "tom" };
            foreach (var name in usernames)
            {
                var user = new IdentityUser
                {
                    Email = name + "@foo.com",
                    NormalizedEmail = name.ToUpper() + "@FOO.COM",
                    UserName = name + "@foo.com",
                    NormalizedUserName = name.ToUpper() + "@FOO.COM",
                    PhoneNumber = "+123456789",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };
                var passwordHash = password.HashPassword(user, "FooBar11!");
                user.PasswordHash = passwordHash;
                users.Add(user);
            }

            // Add the initial users
            modelBuilder.Entity<IdentityUser>().HasData(users);

            // Add a role "admin"
            var adminRole = new IdentityRole
            {
                Name = "admin",
                NormalizedName = "ADMIN"
            };
            modelBuilder.Entity<IdentityRole>().HasData(adminRole);

            // Assign role to the first user in the list
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = adminRole.Id,
                    UserId = users[0].Id
                }
            );

            // Initialize genres
            modelBuilder.Entity<Genre>().HasData(
                new Genre
                {
                    Id = 1,
                    Name = "Mystery"
                },
                new Genre
                {
                    Id = 2,
                    Name = "History"
                },
                new Genre
                {
                    Id = 3,
                    Name = "Science fiction"
                });

            // Initialize list of books
            modelBuilder.Entity<Book>().HasData(
               new Book
               {
                   Id = 1,
                   Name = "Mysterious Adventures",
                   Author = "Ada J. Hawkins",
                   GenreId = 1,
                   Available = true,
                   ImageMimeType = "image/jpeg",
                   ImageName = "first-book.jpg",
                   Recommended = true,
                   DatePublished = new DateTime(2015, 6, 20).ToShortDateString()
               },
               new Book
               {
                   Id = 2,
                   Name = "My Family History",
                   Author = "Janice O. Kaufman",
                   GenreId = 2,
                   Available = true,
                   ImageMimeType = "image/jpeg",
                   ImageName = "second-book.jpg",
                   Recommended = true,
                   DatePublished = new DateTime(2008, 8, 12).ToShortDateString()

               }, new Book
               {
                   Id = 3,
                   Name = "A Wonderful Story ",
                   Author = "Kristin A. McCoy",
                   GenreId = 3,
                   Available = true,
                   ImageMimeType = "image/jpeg",
                   ImageName = "third-book.jpg",
                   Recommended = true,
                   DatePublished = new DateTime(2000, 2, 9).ToShortDateString()
               });
        }
    }
}