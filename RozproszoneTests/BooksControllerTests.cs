using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Rozproszone.Controllers;
using Rozproszone.Models;

namespace RozproszoneTests
{
    [TestFixture]
    public class BooksControllerTests
    {
        DbContextOptions<BookContext> options;
        public DbContextOptions<BookContext> setUp()
        {
            options = new DbContextOptionsBuilder<BookContext>()
                .UseInMemoryDatabase(databaseName: "Books")
                .Options;

            using (var context = new BookContext(options))
            {
                if (context.Books.Count() == 0)
                {
                    context.Books.Add(new Book { Id = 1, Title = "Ludzie bezdomni", Author = "Stefan Żeromski", Pages=255,Publisher="GREG",ReleaseDate="2002-01-01" });
                    context.SaveChanges();
                }
            }

            return options;
        }
        [Test]
        public void GetBooks_ReturnsAllBooksList()
        {
            setUp();
            using (var context = new BookContext(options))
            {
                var BooksController = new BooksController(context);
                var result = BooksController.GetBooks().ToList();

                Assert.That(result.Count.Equals(context.Books.ToList().Count));
            }
        }
        [Test]
        public void GetBook_ReturnsSingleMovieReviewFromRouteTitle()
        {
            setUp();
            using (var context = new BookContext(options))
            {
                String title = "Ludzie bezdomni";
                var BooksController = new BooksController(context);
                var result = BooksController.GetBook(title).ToList();

                Assert.That(result.Count.Equals(1));
            }
        }
        [Test]
        public void PostBook_AddsBook_ReturnsOK()
        {
            setUp();
            using (var context = new BookContext(options))
            {
                var BooksController = new BooksController(context);
                ActionResult result = BooksController.PostBook(new Book { Id = 2, Title = "Krzyżacy", Author = "Henryk Sienkiewicz", Pages = 600, Publisher = "GREG", ReleaseDate = "2001-01-01" }).Result;

                Assert.IsInstanceOf<OkResult>(result);
            }
        }
        [Test]
        public void PutBook_EditUser_ReturnsOk()
        {
            setUp();
            using (var context = new BookContext(options))
            {
                var BooksController = new BooksController(context);
                IActionResult result = BooksController.PutBook(new Book { Id = 1, Title = "Przedwiośnie", Author = "Stefan Żeromski", Pages = 255, Publisher = "GREG", ReleaseDate = "2002-01-01" }, 1);

                Assert.IsInstanceOf<OkResult>(result);
            }
        }
    }
}