using System;
using System.Collections.Generic;
using Labb2_DbFirst_Template.Handlers;
using Labb2_DbFirst_Template.Interfaces;

namespace Labb2_DbFirst_Template.Entities;

public partial class BookTbl 
{

    public string Isbn13 { get; set; } = null!;

    public int? AuthorId { get; set; }

    public string Title { get; set; } = null!;

    public string Language { get; set; } = null!;

    public string? Awards { get; set; }

    public int PublicationYear { get; set; }

    public int? PriceKr { get; set; }

    public virtual AuthorTbl? Author { get; set; } 

    public virtual ICollection<Inventory> InventoryTbls { get; set; } = new List<Inventory>();

    public virtual ICollection<OrderDetailsTbl> OrderDetailsTbls { get; set; } = new List<OrderDetailsTbl>();

    public List<ShopTbl> Shops { get; set; } = new();

}
