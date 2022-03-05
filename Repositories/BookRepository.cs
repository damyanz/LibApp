using System.Collections.Generic;
using LibApp.Models;
using LibApp.Interfaces;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;

namespace LibApp.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _context.Books.Include(book => book.Genre);
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _context.Genre;
        }

        public Book GetBookById(int bookId) {
            return _context.Books.Find(bookId);
        }
    
        public void AddBook(Book book) {
            _context.Books.Add(book);
        }

        public void UpdateBook(Book book)
        {
            _context.Books.Update(book);
        }

        public void DeleteBook(int bookId){
            _context.Books.Remove(GetBookById(bookId));
        }

        public void Save() {
            _context.SaveChanges();
        }
    }
}
