using System;
using System.Collections.Generic;

namespace MtGdbWebAPIbackend.Models;

public partial class Format
{
    public int FormatId { get; set; }

    public string FormatName { get; set; } = null!;

    public int LoginId { get; set; }

    public virtual ICollection<Deck> Decks { get; set; } = new List<Deck>();
}
