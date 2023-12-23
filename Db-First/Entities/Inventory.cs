using System;
using System.Collections.Generic;

namespace Labb2_DbFirst_Template.Entities;

public partial class Inventory
{
    public int ShopId { get; set; }

    public string Isbn13Id { get; set; } = null!;

    public int? InStock { get; set; }

    public virtual BookTbl Isbn13 { get; set; } = null!;

    public virtual ShopTbl ShopTbl { get; set; } = null!;
}
