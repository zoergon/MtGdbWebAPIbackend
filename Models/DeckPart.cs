using System;
using System.Collections.Generic;

namespace MtGdbWebAPIbackend.Models;

public partial class DeckPart
{
    public int PartId { get; set; }

    public string Part { get; set; } = null!;

    public int LoginId { get; set; }

    public virtual Login Login { get; set; } = null!;
}
