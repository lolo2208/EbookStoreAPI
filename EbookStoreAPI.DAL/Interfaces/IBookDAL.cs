using EbookStoreAPI.BE;
using EbookStoreAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStoreAPI.DAL.Interfaces
{
    public interface IBookDAL
    {
        Task<List<BookBE>> GetAllBooksAsync();
        Task<BookBE> CreateBook(BookDTO book);
        Task<BookBE> UpdateBook(BookDTO book);
        Task<BookBE> DeleteBook(int idBook);
        Task<BookBE> FindById(int idBook);
        Task<List<BookBE>> FindByParams(BookDTO book);
        void Detach(BookBE book);
    }
}
