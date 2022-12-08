using BookManagement.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Api.Models
{
    public interface IBookRepository
    {
        Task<IEnumerable<BooksModel>> GetBooks();
        Task<BooksModel> GetBooks(int id);
        Task<BooksModel> AddBooks(BooksModel booksModel);
    }
}
