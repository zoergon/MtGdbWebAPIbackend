using System;
using System.Collections.Generic;

namespace MtGdbWebAPIbackend.Models;

public partial class Token
{
    public int IndexId { get; set; }

    public int DeckId { get; set; }

    public string Id { get; set; } = null!;

    public int Count { get; set; }

    public int LoginId { get; set; }

    public virtual Deck Deck { get; set; } = null!;

    public virtual AllCard IdNavigation { get; set; } = null!;
}
