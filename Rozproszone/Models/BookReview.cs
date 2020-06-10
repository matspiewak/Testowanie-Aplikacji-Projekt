using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rozproszone.Models
{
    public class BookReview
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Review { get; set; }
        public int Rating { get; set; }
    }
}
