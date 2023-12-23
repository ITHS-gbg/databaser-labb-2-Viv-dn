using System;
using System.Collections.Generic;

namespace Labb2_DbFirst_Template.Entities;

public partial class ShopTbl
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public string City { get; set; } = null!;

    public virtual ICollection<CustomersTbl> CustomersTbls { get; set; } = new List<CustomersTbl>();

    public virtual ICollection<Inventory> InventoryTbls { get; set; } = new List<Inventory>();

    public List<BookTbl> Books { get; set; } = new();
}
