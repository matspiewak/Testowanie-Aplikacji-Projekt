using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Rozproszone.Models
{
    public class BookReviewContext : DbContext
    {
        public DbSet<BookReview> BookReviews { get; set; }
        public BookReviewContext(DbContextOptions<BookReviewContext> options) : base(options)
        {

        }

        public static implicit operator BookReviewContext(BookReview v)
        {
            throw new NotImplementedException();
        }
    }
}
