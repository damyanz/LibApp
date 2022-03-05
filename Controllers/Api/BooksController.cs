using AutoMapper;
using LibApp.Data;
using LibApp.Dtos;
using LibApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibApp.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace LibApp.Controllers.Api
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _repository;
        public BooksController(IBookRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<BookDto> GetBooks(string query = null)
        {
            var booksQuery = _repository.GetBooks().Where(b => b.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
            {
                booksQuery = booksQuery.Where(b => b.Name.Contains(query));
            }

            return booksQuery.ToList().Select(_mapper.Map<Book, BookDto>);
        }

        [Authorize(Roles = "StoreManager, Owner")]
        [HttpDelete("{id}")]
        public IActionResult RemoveBook(int id)
        {
            try
            {
                _repository.DeleteBook(id);
                _repository.Save();
            }
            catch (Exception)
            {
                return NotFound();
            }
            return Ok();
        }

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
    }
}
