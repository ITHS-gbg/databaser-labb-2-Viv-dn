using System;
using System.Collections.Generic;

namespace Labb2_DbFirst_Template.Entities;

public partial class CustomersTbl
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int? ShopsId { get; set; }

    public string City { get; set; } = null!;

    public virtual ICollection<OrdersTbl> OrdersTbls { get; set; } = new List<OrdersTbl>();

    public virtual ShopTbl? Shops { get; set; }
}
