using LibApp.Models;
using System.Collections.Generic;

namespace LibApp.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        Book GetBookById(int bookId);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int bookId);
    }
}

