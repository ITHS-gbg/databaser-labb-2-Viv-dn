using System;
using System.Collections.Generic;

namespace Labb2_DbFirst_Template.Entities;

public partial class OrderDetailsTbl
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public string? Isbn13Id { get; set; }

    public int Quantity { get; set; }

    public virtual BookTbl? Isbn13 { get; set; }

    public virtual OrdersTbl? Order { get; set; }
}
