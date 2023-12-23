using Labb2_DbFirst_Template.Entities;
using Microsoft.Identity.Client;

namespace Labb2_DbFirst_Template.Handlers;

public class BookModel
{
    public List<BookTbl> Books { get; set; } 

    public string Isbn13 { get; set; } 

    public int? AuthorId { get; set; } 

    public string Title { get; set; } = string.Empty;

    public string Language { get; set; } = string.Empty;

    public int PublicationYear { get; set; } 

    public double PriceKr { get; set; }

    public List<ShopModel> ShopsId { get; set; } = new();

    //public static void ListAll()
    //{
    //    foreach (var books in BookTbl)
    //    {
    //        Console.WriteLine(books.Title);
    //    }
    //    GlobalContext.Db.SaveChanges();
    //}


}