using System;
using System.Collections.Generic;

namespace MtGdbWebAPIbackend.Models;

public partial class Login
{
    public int LoginId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int AccesslevelId { get; set; }

    public bool Admin { get; set; }

    public virtual ICollection<DeckPart> DeckParts { get; set; } = new List<DeckPart>();
}
