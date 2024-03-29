﻿using System;
using System.Collections.Generic;

namespace MtGdbWebAPIbackend.Models;

public partial class AllCard
{
    public string? AllParts { get; set; }

    public int? ArenaId { get; set; }

    public string? Artist { get; set; }

    public string? ArtistIds { get; set; }

    public string? AttractionLights { get; set; }

    public bool Booster { get; set; }

    public string BorderColor { get; set; } = null!;

    public string? CardBackId { get; set; }

    public string? CardFaces { get; set; }

    public int? CardmarketId { get; set; }

    public double? Cmc { get; set; }

    public string CollectorNumber { get; set; } = null!;

    public string? ColorIdentity { get; set; }

    public string? ColorIndicator { get; set; }

    public string? Colors { get; set; }

    public bool? ContentWarning { get; set; }

    public bool Digital { get; set; }

    public int? EdhrecRank { get; set; }

    public string? Finishes { get; set; }

    public string? FlavorName { get; set; }

    public string? FlavorText { get; set; }

    public bool? Foil { get; set; }

    public string? FrameEffects { get; set; }

    public string Frame { get; set; } = null!;

    public bool FullArt { get; set; }

    public string? Games { get; set; }

    public string? HandModifier { get; set; }

    public bool HighresImage { get; set; }

    public string Id { get; set; } = null!;

    public string? IllustrationId { get; set; }

    public string ImageStatus { get; set; } = null!;

    public string? ImageUris { get; set; }

    public string? Keywords { get; set; }

    public string Lang { get; set; } = null!;

    public string Layout { get; set; } = null!;

    public string? Legalities { get; set; }

    public string? LifeModifier { get; set; }

    public string? Loyalty { get; set; }

    public string? ManaCost { get; set; }

    public int? MtgoId { get; set; }

    public int? MtgoFoilId { get; set; }

    public string? MultiverseIds { get; set; }

    public string? Name { get; set; }

    public bool? Nonfoil { get; set; }

    public string Object { get; set; } = null!;

    public string? OracleId { get; set; }

    public string? OracleText { get; set; }

    public bool Oversized { get; set; }

    public int? PennyRank { get; set; }

    public string? Power { get; set; }

    public string? Preview { get; set; }

    public string? Prices { get; set; }

    public string? PrintedName { get; set; }

    public string? PrintedText { get; set; }

    public string? PrintedTypeLine { get; set; }

    public string PrintsSearchUri { get; set; } = null!;

    public string? ProducedMana { get; set; }

    public bool Promo { get; set; }

    public string? PromoTypes { get; set; }

    public string Rarity { get; set; } = null!;

    public string? RelatedUris { get; set; }

    public DateTime ReleasedAt { get; set; }

    public bool Reprint { get; set; }

    public bool Reserved { get; set; }

    public string RulingsUri { get; set; } = null!;

    public string ScryfallSetUri { get; set; } = null!;

    public string ScryfallUri { get; set; } = null!;

    public string? SecurityStamp { get; set; }

    public string Set { get; set; } = null!;

    public string SetId { get; set; } = null!;

    public string? SetName { get; set; }

    public string SetSearchUri { get; set; } = null!;

    public string SetType { get; set; } = null!;

    public string SetUri { get; set; } = null!;

    public string? Source { get; set; }

    public bool StorySpotlight { get; set; }

    public int? TcgplayerId { get; set; }

    public int? TcgplayerEtchedId { get; set; }

    public bool Textless { get; set; }

    public string? Toughness { get; set; }

    public string? TypeLine { get; set; }

    public string Uri { get; set; } = null!;

    public bool Variation { get; set; }

    public string? VariationOf { get; set; }

    public string? Watermark { get; set; }

    public virtual ICollection<Commander> Commanders { get; set; } = new List<Commander>();

    public virtual ICollection<Companion> Companions { get; set; } = new List<Companion>();

    public virtual ICollection<MainDeck> MainDecks { get; set; } = new List<MainDeck>();

    public virtual ICollection<Maybeboard> Maybeboards { get; set; } = new List<Maybeboard>();

    public virtual ICollection<OwnedCard> OwnedCards { get; set; } = new List<OwnedCard>();

    public virtual ICollection<Sideboard> Sideboards { get; set; } = new List<Sideboard>();

    public virtual ICollection<Token> Tokens { get; set; } = new List<Token>();
}
