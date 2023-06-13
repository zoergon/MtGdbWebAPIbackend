using System;
using System.Collections.Generic;

namespace MtGdbWebAPIbackend.Models;

public partial class Deck
{
    public int DeckId { get; set; }

    public string Name { get; set; } = null!;

    public int? FormatId { get; set; }

    public int LoginId { get; set; }

    public virtual ICollection<Commander> Commanders { get; set; } = new List<Commander>();

    public virtual ICollection<Companion> Companions { get; set; } = new List<Companion>();

    public virtual Format? Format { get; set; }

    public virtual ICollection<MainDeck> MainDecks { get; set; } = new List<MainDeck>();

    public virtual ICollection<Maybeboard> Maybeboards { get; set; } = new List<Maybeboard>();

    public virtual ICollection<Sideboard> Sideboards { get; set; } = new List<Sideboard>();

    public virtual ICollection<Token> Tokens { get; set; } = new List<Token>();
}
