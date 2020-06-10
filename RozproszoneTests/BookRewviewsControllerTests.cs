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
    public class Tests
    {
        DbContextOptions<BookReviewContext> options;
        public DbContextOptions<BookReviewContext> setUp()
        {
            options = new DbContextOptionsBuilder<BookReviewContext>()
                .UseInMemoryDatabase(databaseName: "BookReviews")
                .Options;

            using (var context = new BookReviewContext(options))
            {
                if(context.BookReviews.Count() == 0)
                {
                    context.BookReviews.Add(new BookReview { Id = 1, Rating = 4, Review = "Hey, that's pretty good", Title = "Lalka" });
                    context.SaveChanges();
                }
            }

            return options;
        }
        [Test]
        public void GetBookReviews_ReturnsAllBookReviewsList()
        {
            setUp();
            using(var context = new BookReviewContext(options))
            {
                var bookReviewsController = new BookReviewsController(context);
                var result = bookReviewsController.GetBookReviews().ToList();

                Assert.That(result.Count.Equals(context.BookReviews.ToList().Count));
            }
        }
        [Test]
        public void GetBookReview_ReturnsSingleMovieReviewFromRouteTitle()
        {
            setUp();
            using (var context = new BookReviewContext(options))
            {
                String title = "Lalka";
                var bookReviewsController = new BookReviewsController(context);
                var result = bookReviewsController.GetBookReview(title).ToList();

                Assert.That(result.Count.Equals(1));
            }
        }
        [Test]
        public void PostBookReview_PostUser_ReturnsOK()
        {
            setUp();
            using (var context = new BookReviewContext(options))
            {
                var bookReviewsController = new BookReviewsController(context);
                ActionResult result = bookReviewsController.PostBookReview(new BookReview { Id = 2, Rating = 3, Review = "tl;dr", Title = "Gra o Tron" }).Result;

                Assert.IsInstanceOf<OkResult>(result);
            }
        }
        [Test]
        public void PutBookReview_EditUser_ReturnsOk()
        {
            setUp();
            using (var context = new BookReviewContext(options))
            {
                var bookReviewsController = new BookReviewsController(context);
                IActionResult result = bookReviewsController.PutBookReview(new BookReview { Id = 1, Rating = 2, Review = "Didn't like it", Title = "Lalka" }, 1);

                Assert.IsInstanceOf<OkResult>(result);
            }
        }
    }
}