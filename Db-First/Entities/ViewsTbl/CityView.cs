using System;
using System.Collections.Generic;

namespace Labb2_DbFirst_Template.Entities.ViewsTbl;

public partial class CityView
{
    public string ShipCity { get; set; } = null!;

    public int? ProdCount { get; set; }
}
