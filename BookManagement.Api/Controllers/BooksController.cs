using BookManagement.Api.Model;
using BookManagement.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository booksRepository;

        public BooksController(IBookRepository booksRepository)
        {
            this.booksRepository = booksRepository;
        }

        [HttpPost]
        public async Task<ActionResult<BooksModel>> AddBooks(BooksModel booksModel)
        {
            try
            {
                if(booksModel == null)
                {
                    return BadRequest();
                }
                var addedBookDetails = await booksRepository.AddBooks(booksModel);
                return CreatedAtAction(nameof(GetBooks), new { id = addedBookDetails.Id }, addedBookDetails);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving data from database");

            }
        }

        [HttpGet]
        public async Task<ActionResult> GetBooks()
        {
            try
            {
                return Ok(await booksRepository.GetBooks());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving data from database");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BooksModel>> GetBooks(int id)
        {
            try { 
            var result = await booksRepository.GetBooks(id);
            if(result == null)
            {
                return NotFound();
            }
            return result;
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving data from database");
            }
        }
    }
}
