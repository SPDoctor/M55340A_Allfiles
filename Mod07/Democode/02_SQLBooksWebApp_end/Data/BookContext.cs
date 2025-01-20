using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SQLBooksWebApp.Models;

namespace SQLBooksWebApp.Data
{
    public class BookContext : DbContext
    {
        public BookContext (DbContextOptions<BookContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<SQLBooksWebApp.Models.Book> Book { get; set; } = default!;

        public DbSet<SQLBooksWebApp.Models.Author> Author { get; set; }
    }
}
