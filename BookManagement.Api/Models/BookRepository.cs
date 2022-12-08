using BookManagement.Api.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Api.Models
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext appDbContext;

        public BookRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<BooksModel> AddBooks(BooksModel booksModel)
        {
           var result =  await appDbContext.bookManagements.AddAsync(booksModel);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<BooksModel>> GetBooks()
        {
            return await appDbContext.bookManagements.ToListAsync();
                
        }

        public async Task<BooksModel> GetBooks(int id)
        {
            return await appDbContext.bookManagements.FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
