using System;
using System.Collections.Generic;

namespace Labb2_DbFirst_Template.Entities.ViewsTbl;

public partial class AurthorView
{
    public string AuthorName { get; set; } = null!;

    public int? Age { get; set; }

    public int? BooksCount { get; set; }

    public int? ValueKr { get; set; }
}
