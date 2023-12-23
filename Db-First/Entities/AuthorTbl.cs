using System;
using System.Collections.Generic;

namespace Labb2_DbFirst_Template.Entities;

public partial class AuthorTbl
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string BirthDate { get; set; } = null!;

    public virtual ICollection<BookTbl> BooksTbls { get; set; } = new List<BookTbl>();
}
