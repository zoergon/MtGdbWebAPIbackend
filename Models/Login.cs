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

    public virtual ICollection<Commander> Commanders { get; set; } = new List<Commander>();

    public virtual ICollection<Companion> Companions { get; set; } = new List<Companion>();

    public virtual ICollection<DeckPart> DeckParts { get; set; } = new List<DeckPart>();

    public virtual ICollection<Deck> Decks { get; set; } = new List<Deck>();

    public virtual ICollection<MainDeck> MainDecks { get; set; } = new List<MainDeck>();

    public virtual ICollection<Maybeboard> Maybeboards { get; set; } = new List<Maybeboard>();

    public virtual ICollection<OwnedCard> OwnedCards { get; set; } = new List<OwnedCard>();

    public virtual ICollection<Sideboard> Sideboards { get; set; } = new List<Sideboard>();

    public virtual ICollection<Token> Tokens { get; set; } = new List<Token>();
}
