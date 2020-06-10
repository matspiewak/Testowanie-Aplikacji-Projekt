using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rozproszone.Models;

namespace Rozproszone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private BookContext _context;

        public BooksController(BookContext context)
        {
            _context = context;
            if (_context.Books.Count() == 0)
            {
                _context.Books.Add(new Book { Id = 1, Title = "Lalka", Author = "Bolesław Prus" , Pages = 724, Publisher = "GREG", ReleaseDate = "1890"});
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            return _context.Books.ToList();
        }
        [HttpGet("{title}")]
        public IEnumerable<Book> GetBook([FromRoute]string title)
        {
            return _context.Books.Where(b => b.Title == title);
        }
        [HttpPost("add")]
        public ActionResult<Book> PostBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();

            return Ok();
        }
        [HttpPut("edit/{id}")]
        public IActionResult PutBook(Book book, int id)
        {
            if(id != book.Id)
            {
                return BadRequest();
            }
            _context.Books.Update(book);
            _context.SaveChanges();

            return Ok();
        }
    }
}