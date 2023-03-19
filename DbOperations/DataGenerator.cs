using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BookStore.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Personal Growth"
                    },
                    new Genre
                    {
                        Name = "Science Fiction"
                    },
                    new Genre
                    {
                        Name = "Romance"
                    }
                 );

                context.Books.AddRange(
                    new Book
                    {
                        //Id = 1,
                        Title = "Lean Startup",
                        GenreId = 1,
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 06, 12)
                    },
                    new Book
                    {
                        //Id = 2,
                        Title = "Herland",
                        GenreId = 2,
                        PageCount = 250,
                        PublishDate = new DateTime(2010, 05, 23)
                    },
                    new Book
                    {
                        //Id = 3,
                        Title = "Dune",
                        GenreId = 2,
                        PageCount = 550,
                        PublishDate = new DateTime(2001, 12, 07)
                    }
                );

                context.Authors.AddRange(
                    new Author
                    {
                        Name = "Dan",
                        Lastname = "Brown",
                        DateOfBirth = new DateTime(1964, 06, 22)
                    },
                    new Author
                    {
                        Name = "Eric",
                        Lastname = "Ries",
                        DateOfBirth = new DateTime(1978, 09, 22)
                    },
                    new Author
                    {
                        Name = "Frank",
                        Lastname = "Herbert",
                        DateOfBirth = new DateTime(1920, 10, 08)
                        
                    },
                    new Author
                    {
                        Name = "Charlotte Perkins",
                        Lastname = "Gilman",
                        DateOfBirth = new DateTime(1860, 07, 03)

                    }
                 );
                context.AuthorBooks.AddRange(
                    new AuthorBook
                    {
                        AuthorId = 2,
                        BookId = 1,
                    },
                    new AuthorBook
                    {
                        AuthorId = 4,
                        BookId = 2,
                    },
                    new AuthorBook
                    {
                        AuthorId = 3,
                        BookId = 3,
                    }
                 );

                context.SaveChanges();
            }
               
        }
    }
}
