using EbookStoreAPI.BE;
using EbookStoreAPI.DAL.Interfaces;
using EbookStoreAPI.DBConnection;
using EbookStoreAPI.DTO;
using EbookStoreAPI.Services.EntitiesServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EbookStoreAPI.Controllers.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooks()
        {
            try
            {
                var books = await _bookService.GetAllBooksAsync();
                return Ok(books);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("{idBook}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetBookById(int idBook)
        {
            try
            {
                var findedBook = await _bookService.FindById(idBook);
                return Ok(findedBook);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooksByParams(
                [FromQuery] string? title = null,
                [FromQuery] string? author = null,
                [FromQuery] string? editorial = null
            )
        {
            BookDTO book = new BookDTO()
            {
                Title = title,
                Author = author,
                Editorial = editorial
            };

            try
            {
                var queryBooks = await _bookService.FindByParams(book);
                return Ok(queryBooks);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task <ActionResult<BookDTO>> CreateBook(BookDTO book)
        {
            try
            {
                var addedBook = await _bookService.CreateBook(book);
                return Ok(addedBook);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPut("{idBook}")]
        public async Task<ActionResult<BookDTO>> UpdateBook(BookDTO book, int idBook)
        {
            try
            {
                if (idBook == book.IdBook)
                {
                    var updatedBook = await _bookService.UpdateBook(book);
                    return Ok(updatedBook);
                }
                else
                {
                    return BadRequest();
                }
                
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpDelete("{idBook}")]
        public async Task<ActionResult<BookDTO>> DeleteBook(int idBook)
        {
            try
            {
                {
                    var findedBook = await _bookService.FindById(idBook);
                    if(findedBook != null)
                    {
                        var deletedBook = await _bookService.DeleteBook(findedBook.IdBook);
                        return Ok(deletedBook);
                    }else
                    {
                        return BadRequest();
                    }                
                }
                
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}
