using System;
using System.Collections.Generic;

namespace MtGdbWebAPIbackend.Models;

public partial class Login
{
    public int LoginId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool Admin { get; set; }

    public virtual ICollection<DeckPart> DeckParts { get; set; } = new List<DeckPart>();
}
