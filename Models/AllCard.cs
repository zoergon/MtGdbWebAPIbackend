using System;
using System.Collections.Generic;

namespace MtGdbWebAPIbackend.Models;

public partial class AllCard
{
    public int? ArenaId { get; set; }

    public string Id { get; set; } = null!;

    public string Lang { get; set; } = null!;

    public int? MtgoId { get; set; }

    public int? MtgoFoilId { get; set; }

    public string? MultiverseIds { get; set; }

    public int? TcgplayerId { get; set; }

    public int? TcgplayerEtchedId { get; set; }

    public int? CardmarketId { get; set; }

    public string Object { get; set; } = null!;

    public string? OracleId { get; set; }

    public string PrintsSearchUri { get; set; } = null!;

    public string RulingsUri { get; set; } = null!;

    public string ScryfallUri { get; set; } = null!;

    public string Uri { get; set; } = null!;

    public string? AllParts { get; set; }

    public string? CardFaces { get; set; }

    public double? Cmc { get; set; }

    public string? ColorIdentity { get; set; }

    public string? ColorIndicator { get; set; }

    public string? Colors { get; set; }

    public int? EdhrecRank { get; set; }

    public string? HandModifier { get; set; }

    public string? Keywords { get; set; }

    public string Layout { get; set; } = null!;

    public string? Legalities { get; set; }

    public string? LifeModifier { get; set; }

    public string? Loyalty { get; set; }

    public string? ManaCost { get; set; }

    public string Name { get; set; } = null!;

    public string? OracleText { get; set; }

    public bool Oversized { get; set; }

    public int? PennyRank { get; set; }

    public string? Power { get; set; }

    public string? ProducedMana { get; set; }

    public bool Reserved { get; set; }

    public string? Toughness { get; set; }

    public string? TypeLine { get; set; }

    public string? Artist { get; set; }

    public string? AttractionLights { get; set; }

    public bool Booster { get; set; }

    public string BorderColor { get; set; } = null!;

    public string? CardBackId { get; set; }

    public string CollectorNumber { get; set; } = null!;

    public bool? ContentWarning { get; set; }

    public bool Digital { get; set; }

    public string? Finishes { get; set; }

    public string? FlavorName { get; set; }

    public string? FlavorText { get; set; }

    public string? FrameEffects { get; set; }

    public string Frame { get; set; } = null!;

    public bool FullArt { get; set; }

    public string? Games { get; set; }

    public bool HighresImage { get; set; }

    public string? IllustrationId { get; set; }

    public string ImageStatus { get; set; } = null!;

    public string? ImageUris { get; set; }

    public string? Prices { get; set; }

    public string? PrintedName { get; set; }

    public string? PrintedText { get; set; }

    public string? PrintedTypeLine { get; set; }

    public bool Promo { get; set; }

    public string? PromoTypes { get; set; }

    public string? PurchaseUris { get; set; }

    public string Rarity { get; set; } = null!;

    public string? RelatedUris { get; set; }

    public DateTime ReleasedAt { get; set; }

    public bool Reprint { get; set; }

    public string ScryfallSetUri { get; set; } = null!;

    public string SetName { get; set; } = null!;

    public string SetSearchUri { get; set; } = null!;

    public string SetType { get; set; } = null!;

    public string SetUri { get; set; } = null!;

    public string Set { get; set; } = null!;

    public string SetId { get; set; } = null!;

    public bool StorySpotlight { get; set; }

    public bool Textless { get; set; }

    public bool Variation { get; set; }

    public string? VariationOf { get; set; }

    public string? SecurityStamp { get; set; }

    public string? Watermark { get; set; }

    public DateTime? PreviewedAt { get; set; }

    public string? SourceUri { get; set; }

    public string? Source { get; set; }

    public bool? Foil { get; set; }

    public bool? Nonfoil { get; set; }

    public string? ArtistIds { get; set; }

    public virtual ICollection<Commander> Commanders { get; set; } = new List<Commander>();

    public virtual ICollection<Companion> Companions { get; set; } = new List<Companion>();

    public virtual ICollection<MainDeck> MainDecks { get; set; } = new List<MainDeck>();

    public virtual ICollection<Maybeboard> Maybeboards { get; set; } = new List<Maybeboard>();

    public virtual OwnedCard? OwnedCard { get; set; }

    public virtual ICollection<Sideboard> Sideboards { get; set; } = new List<Sideboard>();

    public virtual ICollection<Token> Tokens { get; set; } = new List<Token>();
}
