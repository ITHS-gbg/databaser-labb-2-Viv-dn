using Db_First;
using Labb2_DbFirst_Template.Entities;
using Labb2_DbFirst_Template.Handlers;
using Microsoft.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace Labb2_DbFirst_Template.Services;

public class ShopRepository
{
    private readonly BooksContext _context;

    public ShopRepository(BooksContext context)
    {
        _context = context;
    }

    public List<ShopModel> GetAllShops()
    {
        return _context.ShopsTbls.Select(s => new ShopModel
        {
            Id = s.Id,
            Name = s.Name,
            Inventory = s.Books.Select(b => new BookModel
            {
                Title = b.Title,
                AuthorId = b.AuthorId,
                Isbn13 = b.Isbn13
            }).ToList()
        }).ToList();
    }

    public ShopModel GetShopById(int id)
    {
        var shop = _context.ShopsTbls.Find(id);
        return new ShopModel
        {
            Id = shop.Id,
            Name = shop.Name,
            Inventory = shop.Books.Select(b => new BookModel
            {
                Title = b.Title,
                AuthorId = b.AuthorId,
                Isbn13 = b.Isbn13
            }).ToList()
        };
    }

    public void AddBookToStore(string isbn13, int shopsId)
    {

        var book = _context.InventoryTbls.FirstOrDefault(p => p.Isbn13Id == isbn13);
        //var shop = _context.InventoryTbls.Single(s => s.ShopId == shopsId);
        var shop = GetShopById;

        if (book != null && shop != null)
        {
            book.ShopId = shopsId;
            _context.SaveChanges();
        }
    }

    public void RemoveBookFromStore(string isbn13)
    {
        var removeBook = _context.InventoryTbls.FirstOrDefault(p => p.Isbn13Id == isbn13);

        if (removeBook != null)
        {
            _context.InventoryTbls.Remove(removeBook);
            _context.SaveChanges();
        }
    }

    //public void ListProducts(ShopModel shop)
    //{
    //    foreach (var book in shop.Isbn13Id)
    //    {
    //        //Console.WriteLine(book.Title);

    //    }
    //}

    public List<BookModel> GetListFromShop1()
    {
        //    List<BookModel> books = new List<BookModel>();
        //    using (SqlConnection connection = new SqlConnection("Data Source =DESKTOP-LC3CJTC;Initial Catalog=Bokhandel;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"))
        //    {
        //        string query = "SELECT * FROM InventoryTbl WHERE ShopId = 1";

        //        SqlCommand command = new SqlCommand(query, connection);
        //        connection.Open();

        //        SqlDataReader reader = command.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            BookModel book = new BookModel();
        //            book.Title = reader["Title"].ToString();
        //            book.Isbn13 = reader["Isbn13"].ToString();

        //            books.Add(book);
        //        }

        //        reader.Close();
        //    }

        //    return books;
        //}

        return _context.BooksTbls.Include(p => p.Title).Select(
            product => new BookModel
            {
                Isbn13 = product.Isbn13,
                Title = product.Title,
                //PriceKr = (double)books.PriceKr,
                //AuthorId = book.AuthorId
            }).ToList();
    }
}


