using System;
using System.Collections.Generic;

namespace Labb2_DbFirst_Template.Entities;

public partial class OrdersTbl
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public string ShipCity { get; set; } = null!;

    public virtual CustomersTbl? Customer { get; set; }

    public virtual ICollection<OrderDetailsTbl> OrderDetailsTbls { get; set; } = new List<OrderDetailsTbl>();
}
