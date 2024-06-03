using AutoMapper;
using EbookStoreAPI.BE;
using EbookStoreAPI.DAL.Interfaces;
using EbookStoreAPI.DBConnection;
using EbookStoreAPI.DTO;
using Microsoft.EntityFrameworkCore;

namespace EbookStoreAPI.DAL.Repositories
{
    public class BookDAL : IBookDAL
    {
        private readonly EbookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookDAL(EbookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookBE> CreateBook(BookDTO book)
        {
            try
            {
                var bookBE = _mapper.Map<BookBE>(book);
                _context.Books.Add(bookBE);
                await _context.SaveChangesAsync();

                await _context.Entry(bookBE).ReloadAsync();

                return bookBE;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el libro.", ex);
            }

        }

        public async Task<BookBE> DeleteBook(int idBook)
        {
            try
            {
                var toDeleteBook = await _context.Books.FindAsync(idBook);

                if (toDeleteBook == null)
                {
                    throw new Exception("Book not found");
                }

                _context.Books.Remove(toDeleteBook);
                await _context.SaveChangesAsync();

                return toDeleteBook;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el libro.", ex);
            }
        }

        public async Task<BookBE> FindById(int idBook)
        {
            try
            {
                var findedBook = await _context.Books.FindAsync(idBook);

                if (findedBook == null)
                {
                    throw new Exception("Book not found");
                }

                return findedBook;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting book", ex);
            }
        }

        public async Task<List<BookBE>> FindByParams(BookDTO book)
        {
            try
            {
                var query = _context.Books.AsQueryable();

                if (!string.IsNullOrEmpty(book.Title))
                {
                    query = query.Where(b => b.Title.Contains(book.Title));
                }

                if (!string.IsNullOrEmpty(book.Author))
                {
                    query = query.Where(b => b.Author.Contains(book.Author));
                }

                if (!string.IsNullOrEmpty(book.Editorial))
                {
                    query = query.Where(b => b.Editorial.Contains(book.Editorial));
                }

                var result = await query.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while finding books by parameters", ex);
            }

        }

        public async Task<List<BookBE>> GetAllBooksAsync()
        {
            if (_context.Books == null)
            {
                throw new Exception("No books found");
            }
            return await _context.Books.ToListAsync();
        }

        public async Task<BookBE> UpdateBook(BookDTO book)
        {
            try
            {
                var existingBook = await _context.Books.FindAsync(book.IdBook);
                var bookBE = _mapper.Map<BookBE>(book);

                if (existingBook == null)
                {
                    throw new Exception("Book not found");
                }

                _context.Entry(existingBook).CurrentValues.SetValues(bookBE);
                await _context.SaveChangesAsync();

                await _context.Entry(existingBook).ReloadAsync();

                return existingBook;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating book", ex);
            }
        }
        public void Detach(BookBE book)
        {
            _context.Entry(book).State = EntityState.Detached;
        }

    }
}
