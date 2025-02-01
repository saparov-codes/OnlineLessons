using System.Text.Json;
using ExamVariant2.Services.DTOs;

namespace ExamVariant2.Repositories;

public class BookRepository : IBookRepository
{
    private readonly List<BookDto> _books;

    private string _jsonPath = "../../../DataAccess/Data/Books.json";

    public BookRepository()
    {
        _books = new List<BookDto>();

        if (File.Exists(_jsonPath) is false)
        {
            File.WriteAllText(_jsonPath, "[]");
        }
    }

    public List<BookDto> GetAllBooksByAuthor(string author)
    {
        var booksByAuthor = new List<BookDto>();
        foreach (var book in _books)
        {
            if (book.Author == author)
            {
                booksByAuthor.Add(book);
            }
        }

        return booksByAuthor;
    }

    public List<BookDto> GetBooksPublishedAfterYear(int year)
    {
        var booksAfterYear = new List<BookDto>();
        foreach (var book in _books)
        {
            if (book.PublishedDate.Year > year)
            {
                booksAfterYear.Add(book);
            }
        }

        return booksAfterYear;
    }

    public List<BookDto> GetBooksSortedByRating()
    {
        return _books.OrderByDescending(book => book.Rating).ToList();
    }

    public List<BookDto> GetBooksWithinPageRange(int minPages, int maxPages)
    {
        var books = new List<BookDto>();
        foreach (var book in _books)
        {
            if (book.Pages >= minPages && book.Pages <= maxPages)
            {
                books.Add(book);
            }
        }
        return books;
    }

    public BookDto GetMostPopularBook()
    {
        //var popular = new BookDto();
        //var max = 0;
        //foreach (var book in _books)
        //{
        //    for (var i = 0; i < _books.Count; i++)
        //    {
        //        if (book.NumberOfCopiesSold > max)
        //        {
        //            max = book.NumberOfCopiesSold;
        //            popular = book;
        //        }
        //    }
        //}

        //return popular;

        return _books.MaxBy(book => book.NumberOfCopiesSold);
    }

    public List<BookDto> GetRecentBooks(int years)
    {
        var books = new List<BookDto>();
        var year = DateTime.Now.Year - years;
        foreach (var book in _books)
        {
            if(book.PublishedDate.Year > year)
            {
                books.Add(book);
            }
        }
        return books;

        //var fromYear = DateTime.Now.Year - years;
        //return _books.Where(book => book.PublishedDate.Year > fromYear).ToList();
    }

    public BookDto GetTopRatedBook()
    {
        return _books.OrderByDescending(_books => _books.Rating).FirstOrDefault();
    }

    public int GetTotalCopiesSoldByAuthor(string author)
    {
        var count = 0;
        var books = GetAllBooksByAuthor(author);
        foreach(var book in books)
        {
            count += book.NumberOfCopiesSold;
        }
        return count;
    }

    public List<BookDto> SearchBooksByTitle(string keyword)
    {
        var booksByTitle = new List<BookDto>();
        foreach (var book in _books)
        {
            if(book.Title == keyword)
            {
                booksByTitle.Add(book);
            }
        }
        return booksByTitle;
    }

    private void SaveBooks()
    {
        var json = JsonSerializer.Serialize(_books);
        File.WriteAllText(_jsonPath, json);
    }
}
