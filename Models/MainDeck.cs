using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MtGdbWebAPIbackend.Models;

public partial class MainDeck
{
    public int IndexId { get; set; }

    public int DeckId { get; set; }

    public string Id { get; set; } = null!;

    public int Count { get; set; }

    public int LoginId { get; set; }
    
    public virtual Deck Deck { get; set; } = null!;
    
    public virtual AllCard IdNavigation { get; set; } = null!;
    //[ForeignKey("DeckId")]
    //public virtual ICollection<Deck> Decks { get; set; } = new List<Deck>();
    ////[ForeignKey("Id")]
    //public virtual ICollection<AllCard> AllCards { get; set; } = new List<AllCard>();
}
