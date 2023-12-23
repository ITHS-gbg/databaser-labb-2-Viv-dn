using Db_First;
using Labb2_DbFirst_Template.Entities;
using Labb2_DbFirst_Template.Handlers;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace Labb2_DbFirst_Template.Services;

public class ProductRepository
{
    private readonly BooksContext _context;
    
    //public List<BookModel> BookTbls { get; set; } = GlobalContext.Db.BookTbls.ToList();
    public ProductRepository(BooksContext context)
    {
        _context = context;
    }

    public List<BookTbl> Books { get; set; } 

    public List<BookModel> GetAllProducts()
    {
        //var book = _context.BooksTbls.
        //return _context.BooksTbls.Select(book)

        return _context.BooksTbls.Select(
            product => new BookModel
            {
                Isbn13 = product.Isbn13,
                Title = product.Title,
                //PriceKr = (double)books.PriceKr,
                //AuthorId = book.AuthorId
            }).ToList();
    }

    public BookModel GetByIsbn13(string isbn)
    {

        var book = _context.BooksTbls.Find(isbn);
        return new BookModel()
        {
            Isbn13 = book.Isbn13,
            Title = book.Title
            //Language = book.Language,
            //PublicationYear = book.PublicationYear,
            //PriceKr = (double)book.PriceKr,
            //AuthorId = book.AuthorId
        };
    }

    public void AddProduct(BookModel book)
    {
        var b = _context.BooksTbls.Add(
            new BookTbl
            {
                Title = book.Title,
                Isbn13 = book.Isbn13,
                //Language = book.Language,
                //PublicationYear = book.PublicationYear,
                //PriceKr = (double)book.PriceKr,
                AuthorId = book.AuthorId

            });
        _context.SaveChanges();
    }

    //public void UpdateProduct(BookModel book)
    //{
    //    var b = _context.BooksTbls.Update(
    //        new BookTbl
    //        {
    //            Isbn13 = book.Isbn13,
    //            Title = book.Title,
    //            //Language = book.Language,
    //            //PublicationYear = book.PublicationYear,
    //            //PriceKr = (double)book.PriceKr,
    //            AuthorId = book.AuthorId
    //        });
    //    _context.SaveChanges();

    //}

    public void RemoveProduct(string Isbn13)
    {
        var book = _context.InventoryTbls.Find(Isbn13);
        _context.InventoryTbls.Remove(book);
        _context.SaveChanges();
    }


}