using System;
using System.Collections.Generic;

namespace MtGdbWebAPIbackend.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string Category1 { get; set; } = null!;

    public int LoginId { get; set; }
}
