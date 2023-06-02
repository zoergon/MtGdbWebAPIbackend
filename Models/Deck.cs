using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MtGdbWebAPIbackend.Models;

public partial class Deck
{
    public int DeckId { get; set; }

    public string Name { get; set; } = null!;

    public string? Format { get; set; }

    public int LoginId { get; set; }
    
    //[ForeignKey("DeckId")]
    public virtual ICollection<Commander> Commanders { get; set; } = new List<Commander>();
    //[ForeignKey("DeckId")]
    public virtual ICollection<Companion> Companions { get; set; } = new List<Companion>();
    //[ForeignKey("DeckId")]
    public virtual ICollection<MainDeck> MainDecks { get; set; } = new List<MainDeck>();
    //[ForeignKey("DeckId")]
    public virtual ICollection<Maybeboard> Maybeboards { get; set; } = new List<Maybeboard>();
    //[ForeignKey("DeckId")]
    public virtual ICollection<Sideboard> Sideboards { get; set; } = new List<Sideboard>();
    //[ForeignKey("DeckId")]
    public virtual ICollection<Token> Tokens { get; set; } = new List<Token>();
}
