using EbookStoreAPI.BE;
using EbookStoreAPI.DAL.Interfaces;
using EbookStoreAPI.DTO;
using EbookStoreAPI.Services.EntitiesServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStoreAPI.Services.EntitiesServices.Repository
{
    public class BookService : IBookService
    {
        private readonly IBookDAL _bookDAL;
        public BookService(IBookDAL bookDAL)
        {
            _bookDAL = bookDAL;
        }
        public async Task<BookBE> CreateBook(BookDTO book)
        {
            return await _bookDAL.CreateBook(book);
        }

        public async Task<BookBE> DeleteBook(int idBook)
        {
            return await _bookDAL.DeleteBook(idBook);
        }

        public void Detach(BookBE book)
        {
            _bookDAL.Detach(book);
        }

        public async Task<BookBE> FindById(int idBook)
        {
            return await _bookDAL.FindById(idBook);
        }

        public async Task<List<BookBE>> FindByParams(BookDTO book)
        {
            return await _bookDAL.FindByParams(book);
        }

        public async Task<List<BookBE>> GetAllBooksAsync()
        {
            return await _bookDAL.GetAllBooksAsync();
        }

        public async Task<BookBE> UpdateBook(BookDTO book)
        {
            return await _bookDAL.UpdateBook(book);
        }
    }
}
