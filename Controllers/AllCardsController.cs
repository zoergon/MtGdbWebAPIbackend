using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MtGdbWebAPIbackend.Models;

namespace MtGdbWebAPIbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllCardsController : ControllerBase
    {
        private readonly MtGdbContext db = new MtGdbContext();

        // Depency Injection -tyyli
        //private readonly MtGdbContext db;

        public AllCardsController(MtGdbContext dbparam)
        {
            db = dbparam;
        }

        // Hakee kaikki AllCards-taulukon kortit
        [HttpGet]
        [Route("")]
        public List<AllCard> GetAllCards()
        {
            List<AllCard> cards = db.AllCards.ToList();

            return cards;

        }

        // Hakee id:n mukaisen yhden kortin
        [HttpGet]
        [Route("{id}")]
        public AllCard GetOneCard(string id)
        {
            AllCard card = db.AllCards.Find(id); // Find-metodi hakee AINA VAIN YHDEN RIVIN PÄÄAVAIMELLA

            return card;
        }

        // Hakee kortin nimen perusteella kaikki hakutulokset
        [HttpGet]
        [Route("name/{key}")]
        public List<AllCard> GetCards(string key) // Hakee jollain tiedolla mätsäävät rivit
        {
            var cards = from n in db.AllCards
                                where n.Name == key
                                select n;

            return cards.ToList();
        }

        // Hakee artistin nimen perusteella kaikki hakutulokset
        [HttpGet]
        [Route("artist/{key}")]
        public List<AllCard> GetArtist(string key)
        {
            var artists = from a in db.AllCards
                            where a.Artist == key
                            select a;

            return artists.ToList();
        }

        // Hakee kortin reunojen värin perusteella kaikki hakutulokset
        [HttpGet]
        [Route("border_color/{key}")]
        public List<AllCard> GetSomeBorderColors(string key)
        {
            var borderColors = from b in db.AllCards
                              where b.BorderColor == key
                              select b;

            return borderColors.ToList();
        }

        // Hakee Cardmarketin id:n perusteella hakutuloksen
        [HttpGet]
        [Route("cardmarketid/{key}")]
        public List<AllCard> GetCardmarketId(int key)
        {
            var cardmarketId = from c in db.AllCards
                               where c.CardmarketId == key
                               select c;

            return cardmarketId.ToList();
        }
        // Hakee Cardmarketin id:n perusteella hakutuloksen
        //[HttpGet]
        //[Route("{cartmarketId}")]
        //public List<AllCard> GetCardmarketId(int id)
        //{
        //    AllCard cardmarketId = db.AllCards.Find(id); // Find-metodi hakee AINA VAIN YHDEN RIVIN PÄÄAVAIMELLA
        //    return cardmarketId;
        //}


        // Hakee kortin mana costin perusteella hakutulokset
        [HttpGet]
        [Route("cmc/{key}")]
        public List<AllCard> GetCmc(double key)
        {
            var cmc = from c in db.AllCards
                               where c.Cmc == key
                               select c;

            return cmc.ToList();
        }

        // Hakee kortin collector numberin perusteella hakutulokset
        [HttpGet]
        [Route("collectornumber/{key}")]
        public List<AllCard> GetCollectorNumbers(string key)
        {
            var collectorNumbers = from c in db.AllCards
                      where c.CollectorNumber == key
                      select c;

            return collectorNumbers.ToList();
        }

        // Hakee kortin color indicatorin perusteella hakutulokset
        [HttpGet]
        [Route("colorindicator/{key}")]
        public List<AllCard> GetColorIndicators(string key)
        {
            var colorIndicators = from c in db.AllCards
                         where c.ColorIndicator == key
                         select c;

            return colorIndicators.ToList();
        }

        // Hakee kortin värien perusteella hakutulokset
        [HttpGet]
        [Route("colors/{key}")]
        public List<AllCard> GetColors(string key)
        {
            var colors = from c in db.AllCards
                                   where c.Colors == key
                                   select c;

            return colors.ToList();
        }

        // Hakee sisältövaroitukselliset hakutulokset
        [HttpGet]
        [Route("contentwarning/{key}")]
        public List<AllCard> GetContentWarnings(bool key)
        {
            var contentWarnings = from c in db.AllCards
                         where c.ContentWarning == key
                         select c;

            return contentWarnings.ToList();
        }

        // Hakee kortin flavor namen perusteella kaikki hakutulokset
        [HttpGet]
        [Route("flavor_name/{key}")]
        public List<AllCard> GetFlavorName(string key)
        {
            var flavorNames = from f in db.AllCards
                           where f.FlavorName == key
                           select f;

            return flavorNames.ToList();
        }

        // Hakee foilit (true/false)
        [HttpGet]
        [Route("foil/{key}")]
        public List<AllCard> GetFoils(bool key)
        {
            var foils = from f in db.AllCards
                        where f.Foil == key
                        select f;

            return foils.ToList();
        }

        // Hakee kortin framen perusteella kaikki hakutulokset
        [HttpGet]
        [Route("frame/{key}")]
        public List<AllCard> GetFrames(string key)
        {
            var frames = from f in db.AllCards
                              where f.Frame == key
                              select f;

            return frames.ToList();
        }

        // Hakee fullart-kortit (true/false)
        [HttpGet]
        [Route("fullart/{key}")]
        public List<AllCard> GetFullArts(bool key)
        {
            var fullArts = from f in db.AllCards
                        where f.FullArt == key
                        select f;

            return fullArts.ToList();
        }

        // Hakee kortit, joissa on highres image (true/false)
        [HttpGet]
        [Route("highresimage/{key}")]
        public List<AllCard> GetHighresImages(bool key)
        {
            var highresImage = from h in db.AllCards
                           where h.HighresImage == key
                           select h;

            return highresImage.ToList();
        }

        // Hakee kortin kielen perusteella
        [HttpGet]
        [Route("lang/{key}")]
        public List<AllCard> GetLang(string key)
        {
            var lang = from l in db.AllCards
                           where l.Lang == key
                           select l;

            return lang.ToList();
        }

        // Hakee kortin layoutin perusteella
        [HttpGet]
        [Route("layout/{key}")]
        public List<AllCard> GetLayouts(string key)
        {
            var layouts = from l in db.AllCards
                       where l.Layout == key
                       select l;

            return layouts.ToList();
        }

        // Hakee kortin mana costin perusteella
        [HttpGet]
        [Route("manacost/{key}")]
        public List<AllCard> GetManaCosts(string key)
        {
            var manaCosts = from m in db.AllCards
                          where m.ManaCost == key
                          select m;

            return manaCosts.ToList();
        }

        // Hakee nonfoilit (true/false)
        [HttpGet]
        [Route("nonfoil/{key}")]
        public List<AllCard> GetNonfoils(bool key)
        {
            var nonfoils = from n in db.AllCards
                        where n.Nonfoil == key
                        select n;

            return nonfoils.ToList();
        }

        // Hakee objectin perusteella
        [HttpGet]
        [Route("object/{key}")]
        public List<AllCard> GetObjects(string key)
        {
            var objects = from o in db.AllCards
                            where o.Object == key
                            select o;

            return objects.ToList();
        }

        // Hakee oversized kortit (true/false)
        [HttpGet]
        [Route("oversize/{key}")]
        public List<AllCard> GetOversizeds(bool key)
        {
            var oversizeds = from o in db.AllCards
                           where o.Oversized == key
                           select o;

            return oversizeds.ToList();
        }

        // Hakee kortin powerin perusteella
        [HttpGet]
        [Route("power/{key}")]
        public List<AllCard> GetPowers(string key)
        {
            var powers = from p in db.AllCards
                          where p.Power == key
                          select p;

            return powers.ToList();
        }

        // Hakee kortin printatun nimen perusteella
        [HttpGet]
        [Route("printedname/{key}")]
        public List<AllCard> GetPrintedNames(string key)
        {
            var printedNames = from p in db.AllCards
                         where p.PrintedName == key
                         select p;

            return printedNames.ToList();
        }

        // Hakee kortin printatun nimen perusteella
        [HttpGet]
        [Route("printedtypeline/{key}")]
        public List<AllCard> GetPrintedTypeLines(string key)
        {
            var printedTypeLines = from p in db.AllCards
                               where p.PrintedTypeLine == key
                               select p;

            return printedTypeLines.ToList();
        }

        // Hakee kortin tuottaman manan perusteella
        [HttpGet]
        [Route("producedmana/{key}")]
        public List<AllCard> GetProducedMana(string key)
        {
            var producedMana = from p in db.AllCards
                                   where p.ProducedMana == key
                                   select p;

            return producedMana.ToList();
        }

        // Hakee kaikki promo-kortit (true/false)
        [HttpGet]
        [Route("promo/{key}")]
        public List<AllCard> GetPromos(bool key)
        {
            var promos = from p in db.AllCards
                             where p.Promo == key
                             select p;

            return promos.ToList();
        }

        // Hakee rarityn perusteella kaikki kortit
        [HttpGet]
        [Route("rarity/{key}")]
        public List<AllCard> GetRarities(string key)
        {
            var rarities = from r in db.AllCards
                               where r.Rarity == key
                               select r;

            return rarities.ToList();
        }

        // Hakee kaikki reprintatut kortit (true/false)
        [HttpGet]
        [Route("reprint/{key}")]
        public List<AllCard> GetReprints(bool key)
        {
            var reprints = from r in db.AllCards
                         where r.Reprint == key
                         select r;

            return reprints.ToList();
        }

        // Hakee kaikki reserved listin kortit (true/false)
        [HttpGet]
        [Route("reserved/{key}")]
        public List<AllCard> GetReserveds(bool key)
        {
            var reserveds = from r in db.AllCards
                           where r.Reserved == key
                           select r;

            return reserveds.ToList();
        }

        // Hakee security stampin perusteella kaikki hakutulokset
        [HttpGet]
        [Route("securitystamp/{key}")]
        public List<AllCard> GetSecurityStamps(string key)
        {
            var securityStamps = from s in db.AllCards
                           where s.SecurityStamp == key
                           select s;

            return securityStamps.ToList();
        }

        // Hakee sarjan tunnisteen perusteella kaikki hakutulokset. Ts. kaikki kortit, jotka vastaavat ko. tunnistetta.
        [HttpGet]
        [Route("set/{key}")]
        public List<AllCard> GetSets(string key)
        {
            var sets = from s in db.AllCards
                            where s.Set == key
                            select s;

            return sets.ToList();
        }

        // Hakee sarjan set_id:n perusteella kaikki hakutulokset
        [HttpGet]
        [Route("setid/{key}")]
        public List<AllCard> GetSetIds(string key)
        {
            var setIds = from s in db.AllCards
                       where s.SetId == key
                       select s;

            return setIds.ToList();
        }

        // Hakee sarjan nimen (set_name) perusteella kaikki hakutulokset
        [HttpGet]
        [Route("setname/{key}")]
        public List<AllCard> GetSetNames(string key)
        {
            var setNames = from s in db.AllCards
                         where s.SetName == key
                         select s;

            return setNames.ToList();
        }

        // Hakee sarjan set_type:n perusteella kaikki hakutulokset
        [HttpGet]
        [Route("settype/{key}")]
        public List<AllCard> GetSetTypes(string key)
        {
            var setTypes = from s in db.AllCards
                           where s.SetType == key
                           select s;

            return setTypes.ToList();
        }

        // Hakee kaikki story spotlight kortit (true/false)
        [HttpGet]
        [Route("storyspotlight/{key}")]
        public List<AllCard> GetStorySpotlights(bool key)
        {
            var storySpotlights = from s in db.AllCards
                            where s.StorySpotlight == key
                            select s;

            return storySpotlights.ToList();
        }

        // Hakee kaikki textless kortit (true/false)
        [HttpGet]
        [Route("textless/{key}")]
        public List<AllCard> GetTextless(bool key)
        {
            var textless = from t in db.AllCards
                            where t.Textless == key
                            select t;

            return textless.ToList();
        }

        // Hakee kortin toughnessin perusteella kaikki hakutulokset
        [HttpGet]
        [Route("toughness/{key}")]
        public List<AllCard> GetToughness(string key)
        {
            var toughness = from t in db.AllCards
                           where t.Toughness == key
                           select t;

            return toughness.ToList();
        }

        // Hakee kortin type_linen perusteella kaikki hakutulokset
        //[HttpGet]
        //[Route("typeline/{key}")]
        //public List<AllCard> GetTypeLines(string key)
        //{
        //    var typeLines = from t in db.AllCards
        //                    where t.TypeLine == key
        //                    select t;

        //    return typeLines.ToList();
        //}

        // Hakee kaikki variationit (true/false)
        [HttpGet]
        [Route("variation/{key}")]
        public List<AllCard> GetVariations(bool key)
        {
            var variations = from v in db.AllCards
                           where v.Variation == key
                           select v;

            return variations.ToList();
        }

        // Hakee minkä variaton of -perusteella kaikki hakutulokset
        //[HttpGet]
        //[Route("typeline/{key}")]
        //public List<AllCard> GetVariationOf(string key)
        //{
        //    var variationOf = from v in db.AllCards
        //                    where v.VariationOf == key
        //                    select v;

        //    return variationOf.ToList();
        //}

        // Hakee watermarkin perusteella kaikki hakutulokset
        [HttpGet]
        [Route("watermark/{key}")]
        public List<AllCard> GetWatermarks(string key)
        {
            var watermarks = from w in db.AllCards
                              where w.Watermark == key
                              select w;

            return watermarks.ToList();
        }
    }
}
