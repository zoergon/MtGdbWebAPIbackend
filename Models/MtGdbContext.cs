using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MtGdbWebAPIbackend.Models;

public partial class MtGdbContext : DbContext
{
    public MtGdbContext()
    {
    }

    public MtGdbContext(DbContextOptions<MtGdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AllCard> AllCards { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Commander> Commanders { get; set; }

    public virtual DbSet<Companion> Companions { get; set; }

    public virtual DbSet<Deck> Decks { get; set; }

    public virtual DbSet<DeckPart> DeckParts { get; set; }

    public virtual DbSet<Format> Formats { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<MainDeck> MainDecks { get; set; }

    public virtual DbSet<Maybeboard> Maybeboards { get; set; }

    public virtual DbSet<OwnedCard> OwnedCards { get; set; }

    public virtual DbSet<Sideboard> Sideboards { get; set; }

    public virtual DbSet<Token> Tokens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-U1GQ57A\\SQLEXPRESS;Database=MtGdb;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AllCard>(entity =>
        {
            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.AllParts).HasColumnName("all_parts");
            entity.Property(e => e.ArenaId).HasColumnName("arena_id");
            entity.Property(e => e.Artist)
                .HasMaxLength(100)
                .HasColumnName("artist");
            entity.Property(e => e.ArtistIds).HasColumnName("artist_ids");
            entity.Property(e => e.AttractionLights).HasColumnName("attraction_lights");
            entity.Property(e => e.Booster).HasColumnName("booster");
            entity.Property(e => e.BorderColor)
                .HasMaxLength(10)
                .HasColumnName("border_color");
            entity.Property(e => e.CardBackId)
                .HasMaxLength(50)
                .HasColumnName("card_back_id");
            entity.Property(e => e.CardFaces).HasColumnName("card_faces");
            entity.Property(e => e.CardmarketId).HasColumnName("cardmarket_id");
            entity.Property(e => e.Cmc).HasColumnName("cmc");
            entity.Property(e => e.CollectorNumber)
                .HasMaxLength(10)
                .HasColumnName("collector_number");
            entity.Property(e => e.ColorIdentity).HasColumnName("color_identity");
            entity.Property(e => e.ColorIndicator).HasColumnName("color_indicator");
            entity.Property(e => e.Colors).HasColumnName("colors");
            entity.Property(e => e.ContentWarning).HasColumnName("content_warning");
            entity.Property(e => e.Digital).HasColumnName("digital");
            entity.Property(e => e.EdhrecRank).HasColumnName("edhrec_rank");
            entity.Property(e => e.Finishes).HasColumnName("finishes");
            entity.Property(e => e.FlavorName)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_100_CI_AI_SC_UTF8")
                .HasColumnName("flavor_name");
            entity.Property(e => e.FlavorText)
                .UseCollation("Latin1_General_100_CI_AI_SC_UTF8")
                .HasColumnName("flavor_text");
            entity.Property(e => e.Foil).HasColumnName("foil");
            entity.Property(e => e.Frame)
                .HasMaxLength(10)
                .HasColumnName("frame");
            entity.Property(e => e.FrameEffects).HasColumnName("frame_effects");
            entity.Property(e => e.FullArt).HasColumnName("full_art");
            entity.Property(e => e.Games).HasColumnName("games");
            entity.Property(e => e.HandModifier)
                .HasMaxLength(10)
                .HasColumnName("hand_modifier");
            entity.Property(e => e.HighresImage).HasColumnName("highres_image");
            entity.Property(e => e.IllustrationId)
                .HasMaxLength(50)
                .HasColumnName("illustration_id");
            entity.Property(e => e.ImageStatus)
                .HasMaxLength(25)
                .HasColumnName("image_status");
            entity.Property(e => e.ImageUris).HasColumnName("image_uris");
            entity.Property(e => e.Keywords).HasColumnName("keywords");
            entity.Property(e => e.Lang)
                .HasMaxLength(3)
                .HasColumnName("lang");
            entity.Property(e => e.Layout)
                .HasMaxLength(25)
                .HasColumnName("layout");
            entity.Property(e => e.Legalities).HasColumnName("legalities");
            entity.Property(e => e.LifeModifier)
                .HasMaxLength(10)
                .HasColumnName("life_modifier");
            entity.Property(e => e.Loyalty)
                .HasMaxLength(10)
                .HasColumnName("loyalty");
            entity.Property(e => e.ManaCost)
                .HasMaxLength(25)
                .HasColumnName("mana_cost");
            entity.Property(e => e.MtgoFoilId).HasColumnName("mtgo_foil_id");
            entity.Property(e => e.MtgoId).HasColumnName("mtgo_id");
            entity.Property(e => e.MultiverseIds).HasColumnName("multiverse_ids");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .UseCollation("Latin1_General_100_CI_AI_SC_UTF8")
                .HasColumnName("name");
            entity.Property(e => e.Nonfoil).HasColumnName("nonfoil");
            entity.Property(e => e.Object)
                .HasMaxLength(10)
                .HasColumnName("object");
            entity.Property(e => e.OracleId)
                .HasMaxLength(50)
                .HasColumnName("oracle_id");
            entity.Property(e => e.OracleText)
                .UseCollation("Latin1_General_100_CI_AI_SC_UTF8")
                .HasColumnName("oracle_text");
            entity.Property(e => e.Oversized).HasColumnName("oversized");
            entity.Property(e => e.PennyRank).HasColumnName("penny_rank");
            entity.Property(e => e.Power)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_100_CI_AI_SC_UTF8")
                .HasColumnName("power");
            entity.Property(e => e.Preview).HasColumnName("preview");
            entity.Property(e => e.Prices).HasColumnName("prices");
            entity.Property(e => e.PrintedName)
                .HasMaxLength(100)
                .UseCollation("Latin1_General_100_CI_AI_SC_UTF8")
                .HasColumnName("printed_name");
            entity.Property(e => e.PrintedText)
                .UseCollation("Latin1_General_100_CI_AI_SC_UTF8")
                .HasColumnName("printed_text");
            entity.Property(e => e.PrintedTypeLine)
                .HasMaxLength(100)
                .UseCollation("Latin1_General_100_CI_AI_SC_UTF8")
                .HasColumnName("printed_type_line");
            entity.Property(e => e.PrintsSearchUri).HasColumnName("prints_search_uri");
            entity.Property(e => e.ProducedMana).HasColumnName("produced_mana");
            entity.Property(e => e.Promo).HasColumnName("promo");
            entity.Property(e => e.PromoTypes).HasColumnName("promo_types");
            entity.Property(e => e.Rarity)
                .HasMaxLength(15)
                .HasColumnName("rarity");
            entity.Property(e => e.RelatedUris).HasColumnName("related_uris");
            entity.Property(e => e.ReleasedAt)
                .HasColumnType("date")
                .HasColumnName("released_at");
            entity.Property(e => e.Reprint).HasColumnName("reprint");
            entity.Property(e => e.Reserved).HasColumnName("reserved");
            entity.Property(e => e.RulingsUri).HasColumnName("rulings_uri");
            entity.Property(e => e.ScryfallSetUri).HasColumnName("scryfall_set_uri");
            entity.Property(e => e.ScryfallUri).HasColumnName("scryfall_uri");
            entity.Property(e => e.SecurityStamp)
                .HasMaxLength(15)
                .HasColumnName("security_stamp");
            entity.Property(e => e.Set)
                .HasMaxLength(10)
                .HasColumnName("set");
            entity.Property(e => e.SetId)
                .HasMaxLength(50)
                .HasColumnName("set_id");
            entity.Property(e => e.SetName)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_100_CI_AI_SC_UTF8")
                .HasColumnName("set_name");
            entity.Property(e => e.SetSearchUri).HasColumnName("set_search_uri");
            entity.Property(e => e.SetType)
                .HasMaxLength(15)
                .HasColumnName("set_type");
            entity.Property(e => e.SetUri).HasColumnName("set_uri");
            entity.Property(e => e.Source).HasColumnName("source");
            entity.Property(e => e.StorySpotlight).HasColumnName("story_spotlight");
            entity.Property(e => e.TcgplayerEtchedId).HasColumnName("tcgplayer_etched_id");
            entity.Property(e => e.TcgplayerId).HasColumnName("tcgplayer_id");
            entity.Property(e => e.Textless).HasColumnName("textless");
            entity.Property(e => e.Toughness)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_100_CI_AI_SC_UTF8")
                .HasColumnName("toughness");
            entity.Property(e => e.TypeLine)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_100_CI_AI_SC_UTF8")
                .HasColumnName("type_line");
            entity.Property(e => e.Uri).HasColumnName("uri");
            entity.Property(e => e.Variation).HasColumnName("variation");
            entity.Property(e => e.VariationOf).HasColumnName("variation_of");
            entity.Property(e => e.Watermark)
                .HasMaxLength(15)
                .HasColumnName("watermark");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Category1)
                .HasMaxLength(50)
                .HasColumnName("category");
            entity.Property(e => e.LoginId).HasColumnName("login_id");
        });

        modelBuilder.Entity<Commander>(entity =>
        {
            entity.HasKey(e => e.IndexId);

            entity.Property(e => e.IndexId).HasColumnName("index_id");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.DeckId).HasColumnName("deck_id");
            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.LoginId).HasColumnName("login_id");

            entity.HasOne(d => d.Deck).WithMany(p => p.Commanders)
                .HasForeignKey(d => d.DeckId)
                //.OnDelete(DeleteBehavior.ClientSetNull)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Commanders_Decks");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.Commanders)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Commanders_AllCards");

            entity.HasOne(d => d.Login).WithMany(p => p.Commanders)
                .HasForeignKey(d => d.LoginId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Commanders_Logins");
        });

        modelBuilder.Entity<Companion>(entity =>
        {
            entity.HasKey(e => e.IndexId);

            entity.Property(e => e.IndexId).HasColumnName("index_id");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.DeckId).HasColumnName("deck_id");
            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.LoginId).HasColumnName("login_id");

            entity.HasOne(d => d.Deck).WithMany(p => p.Companions)
                .HasForeignKey(d => d.DeckId)
                //.OnDelete(DeleteBehavior.ClientSetNull)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Companions_Decks");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.Companions)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Companions_AllCards");

            entity.HasOne(d => d.Login).WithMany(p => p.Companions)
                .HasForeignKey(d => d.LoginId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Companions_Logins");
        });

        modelBuilder.Entity<Deck>().Navigation(e => e.Commanders).AutoInclude();
        modelBuilder.Entity<Deck>().Navigation(e => e.Companions).AutoInclude();
        modelBuilder.Entity<Deck>().Navigation(e => e.Format).AutoInclude();
        modelBuilder.Entity<Deck>().Navigation(e => e.MainDecks).AutoInclude();
        modelBuilder.Entity<Deck>().Navigation(e => e.Maybeboards).AutoInclude();
        modelBuilder.Entity<Deck>().Navigation(e => e.Sideboards).AutoInclude();
        modelBuilder.Entity<Deck>().Navigation(e => e.Tokens).AutoInclude();

        modelBuilder.Entity<Deck>(entity =>
        {
            entity.Property(e => e.DeckId).HasColumnName("deck_id");
            entity.Property(e => e.FormatId).HasColumnName("format_id");
            entity.Property(e => e.LoginId).HasColumnName("login_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.Format).WithMany(p => p.Decks)
                .HasForeignKey(d => d.FormatId)
                .HasConstraintName("FK_Decks_Formats");

            entity.HasOne(d => d.Login).WithMany(p => p.Decks)
                .HasForeignKey(d => d.LoginId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Decks_Logins");
        });

        modelBuilder.Entity<DeckPart>(entity =>
        {
            entity.HasKey(e => e.PartId);

            entity.Property(e => e.PartId).HasColumnName("part_id");
            entity.Property(e => e.LoginId).HasColumnName("login_id");
            entity.Property(e => e.Part)
                .HasMaxLength(50)
                .HasColumnName("part");

            entity.HasOne(d => d.Login).WithMany(p => p.DeckParts)
                .HasForeignKey(d => d.LoginId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DeckParts_Logins");
        });

        modelBuilder.Entity<Format>(entity =>
        {
            entity.Property(e => e.FormatId).HasColumnName("format_id");
            entity.Property(e => e.FormatName)
                .HasMaxLength(100)
                .HasColumnName("format");
            entity.Property(e => e.LoginId).HasColumnName("login_id");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.Property(e => e.LoginId).HasColumnName("login_id");
            entity.Property(e => e.AccesslevelId).HasColumnName("accesslevel_id");
            entity.Property(e => e.Admin).HasColumnName("admin");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        modelBuilder.Entity<MainDeck>(entity =>
        {
            entity.HasKey(e => e.IndexId);

            entity.Property(e => e.IndexId).HasColumnName("index_id");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.DeckId).HasColumnName("deck_id");
            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.LoginId).HasColumnName("login_id");

            entity.HasOne(d => d.Deck).WithMany(p => p.MainDecks)
                .HasForeignKey(d => d.DeckId)
                //.OnDelete(DeleteBehavior.ClientSetNull)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_MainDecks_Decks");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.MainDecks)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MainDecks_AllCards");

            entity.HasOne(d => d.Login).WithMany(p => p.MainDecks)
                .HasForeignKey(d => d.LoginId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MainDecks_Logins");
        });

        modelBuilder.Entity<Maybeboard>(entity =>
        {
            entity.HasKey(e => e.IndexId);

            entity.Property(e => e.IndexId).HasColumnName("index_id");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.DeckId).HasColumnName("deck_id");
            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.LoginId).HasColumnName("login_id");

            entity.HasOne(d => d.Deck).WithMany(p => p.Maybeboards)
                .HasForeignKey(d => d.DeckId)
                //.OnDelete(DeleteBehavior.ClientSetNull)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Maybeboards_Decks");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.Maybeboards)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Maybeboards_AllCards");

            entity.HasOne(d => d.Login).WithMany(p => p.Maybeboards)
                .HasForeignKey(d => d.LoginId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Maybeboards_Logins");
        });

        modelBuilder.Entity<OwnedCard>().Navigation(e => e.IdNavigation).AutoInclude();        

        modelBuilder.Entity<OwnedCard>(entity =>
        {
            entity.HasKey(e => e.IndexId).HasName("PK_OwnedCards_1");

            entity.Property(e => e.IndexId).HasColumnName("index_id");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.LoginId).HasColumnName("login_id");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.OwnedCards)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OwnedCards_AllCards");

            entity.HasOne(d => d.Login).WithMany(p => p.OwnedCards)
                .HasForeignKey(d => d.LoginId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OwnedCards_Logins");
        });

        modelBuilder.Entity<Sideboard>(entity =>
        {
            entity.HasKey(e => e.IndexId).HasName("PK_Sideboards_1");

            entity.Property(e => e.IndexId).HasColumnName("index_id");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.DeckId).HasColumnName("deck_id");
            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.LoginId).HasColumnName("login_id");

            entity.HasOne(d => d.Deck).WithMany(p => p.Sideboards)
                .HasForeignKey(d => d.DeckId)
                //.OnDelete(DeleteBehavior.ClientSetNull)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Sideboards_Decks");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.Sideboards)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sideboards_AllCards");

            entity.HasOne(d => d.Login).WithMany(p => p.Sideboards)
                .HasForeignKey(d => d.LoginId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sideboards_Logins");
        });

        modelBuilder.Entity<Token>(entity =>
        {
            entity.HasKey(e => e.IndexId).HasName("PK_Tokens_1");

            entity.Property(e => e.IndexId).HasColumnName("index_id");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.DeckId).HasColumnName("deck_id");
            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.LoginId).HasColumnName("login_id");

            entity.HasOne(d => d.Deck).WithMany(p => p.Tokens)
                .HasForeignKey(d => d.DeckId)
                //.OnDelete(DeleteBehavior.ClientSetNull)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Tokens_Decks");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.Tokens)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tokens_AllCards");

            entity.HasOne(d => d.Login).WithMany(p => p.Tokens)
                .HasForeignKey(d => d.LoginId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tokens_Logins");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
