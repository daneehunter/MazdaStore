using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MusicStore.Models;

namespace MusicStore.EntityContext
{
    public class SampleData : DropCreateDatabaseIfModelChanges<MusicStoreEntities>
    {
        protected override void Seed(MusicStoreEntities context)
        {
            var genres = new List<Genre>
            {
                new Genre { Name = "Hatchback" },
                new Genre { Name = "Sedan" },
                new Genre { Name = "SUV" },
                new Genre { Name = "Roadster" },
                new Genre { Name = "Pickup"},
                new Genre { Name = "Minivan"}
            };

            var artists = new List<Artist>
            {
                new Artist { Name = "Mazda" }
            };

            new List<Album>
            {
                new Album { Title = "Mazda 2", Genre = genres.Single(g => g.Name == "Hatchback"), Price = 15990M, Artist = artists.Single(a => a.Name == "Mazda"), AlbumArtUrl = "/Content/Images/Bolt/m2_hatchback.png",Front="/content/Images/Details/Mazda2-hatchback/mazda2-elolrol.png",Back="/content/Images/Details/Mazda2-hatchback/mazda2-hatulrol.png",Engine="/content/Images/Details/Mazda2-hatchback/mazda2-engine.png",Interior="/content/Images/Details/Mazda2-hatchback/mazda2-interior.png"  },
                new Album { Title = "Mazda 3", Genre = genres.Single(g => g.Name == "Hatchback"), Price = 23990M, Artist = artists.Single(a => a.Name == "Mazda"), AlbumArtUrl = "/Content/Images/Bolt/m3_hatchback.png",Front="/content/Images/Details/Mazda3-hatchback/mazda3-front.png",Back="/content/Images/Details/Mazda3-hatchback/mazda3-back.png",Engine="/content/Images/Details/Mazda3-hatchback/mazda3-engine.png",Interior="/content/Images/Details/Mazda3-hatchback/mazda3-interior.png" },
                new Album { Title = "Mazda 3", Genre = genres.Single(g => g.Name == "Sedan"), Price = 21445M, Artist = artists.Single(a => a.Name == "Mazda"), AlbumArtUrl = "/Content/Images/Bolt/m3_sedan.png",Front="/content/Images/Details/Mazda3-sedan/mazda3-front.png",Back="/content/Images/Details/Mazda3-sedan/mazda3-back.png",Engine="/content/Images/Details/Mazda3-sedan/mazda3-engine.png",Interior="/content/Images/Details/Mazda3-sedan/mazda3-interior.png"  },
                new Album { Title = "Mazda 6", Genre = genres.Single(g => g.Name == "Sedan"), Price = 25045M, Artist = artists.Single(a => a.Name == "Mazda"), AlbumArtUrl = "/Content/Images/Bolt/m6_sedan.png",Front="/content/Images/Details/Mazda6-sedan/mazda6-front.png",Back="/content/Images/Details/Mazda6-sedan/mazda6-back.png",Engine="/content/Images/Details/Mazda6-sedan/mazda6-engine.png",Interior="/content/Images/Details/Mazda6-sedan/mazda6-interior.png"  },
                new Album { Title = "Mazda CX-3", Genre = genres.Single(g => g.Name == "SUV"), Price = 21740M, Artist = artists.Single(a => a.Name == "Mazda"), AlbumArtUrl = "/Content/Images/Bolt/mcx3_suv.png",Front="/content/Images/Details/Mazdacx3-SUV/mazdacx3-front.png",Back="/content/Images/Details/Mazdacx3-SUV/mazdacx3-back.png",Engine="/content/Images/Details/Mazdacx3-SUV/mazdacx3-engine.png",Interior="/content/Images/Details/Mazdacx3-SUV/mazdacx3-interior.png"  },
                new Album { Title = "Mazda Tribute", Genre = genres.Single(g => g.Name == "SUV"), Price = 3800M, Artist = artists.Single(a => a.Name == "Mazda"), AlbumArtUrl = "/Content/Images/Bolt/mtribute_suv.png",Front="/content/Images/Details/Mazdatribute-SUV/mazdatribute-front.png",Back="/content/Images/Details/Mazdatribute-SUV/mazdatribute-back.png",Engine="/content/Images/Details/Mazdatribute-SUV/mazdatribute-engine.png",Interior="/content/Images/Details/Mazdatribute-SUV/mazdatribute-interior.png"  },
                new Album { Title = "Mazda CX-30", Genre = genres.Single(g => g.Name == "SUV"), Price = 23000M, Artist = artists.Single(a => a.Name == "Mazda"), AlbumArtUrl = "/Content/Images/Bolt/mcx30_suv.png",Front="/content/Images/Details/Mazdacx30-SUV/mazdacx30-front.png",Back="/content/Images/Details/Mazdacx30-SUV/mazdacx30-back.png",Engine="/content/Images/Details/Mazdacx30-SUV/mazdacx30-engine.png",Interior="/content/Images/Details/Mazdacx30-SUV/mazdacx30-interior.png"  },
                new Album { Title = "Mazda CX-5", Genre = genres.Single(g => g.Name == "SUV"), Price = 26370M, Artist = artists.Single(a => a.Name == "Mazda"), AlbumArtUrl = "/Content/Images/Bolt/mcx5_suv.png",Front="/content/Images/Details/Mazdacx5-SUV/mazdacx5-front.png",Back="/content/Images/Details/Mazdacx5-SUV/mazdacx5-back.png",Engine="/content/Images/Details/Mazdacx5-SUV/mazdacx5-engine.png",Interior="/content/Images/Details/Mazdacx5-SUV/mazdacx5-interior.png"  },
                new Album { Title = "Mazda CX-9", Genre = genres.Single(g => g.Name == "SUV"), Price = 35060M, Artist = artists.Single(a => a.Name == "Mazda"), AlbumArtUrl = "/Content/Images/Bolt/mcx9_suv.png",Front="/content/Images/Details/Mazdacx9-SUV/mazdacx9-front.png",Back="/content/Images/Details/Mazdacx9-SUV/mazdacx9-back.png",Engine="/content/Images/Details/Mazdacx9-SUV/mazdacx9-engine.png",Interior="/content/Images/Details/Mazdacx9-SUV/mazdacx9-interior.png"  },
                new Album { Title = "Mazda MX-5 Miata", Genre = genres.Single(g => g.Name == "Roadster"), Price = 27525M, Artist = artists.Single(a => a.Name == "Mazda"), AlbumArtUrl = "/Content/Images/Bolt/mmx5_roadster.png",Front="/content/Images/Details/Mazdamx5-roadster/mazdamx5-front.png",Back="/content/Images/Details/Mazdamx5-roadster/mazdamx5-back.png",Engine="/content/Images/Details/Mazdamx5-roadster/mazdamx5-engine.png",Interior="/content/Images/Details/Mazdamx5-roadster/mazdamx5-interior.png"  },
                new Album { Title = "Mazda MX-5 Miata RF", Genre = genres.Single(g => g.Name == "Roadster"), Price = 33990M, Artist = artists.Single(a => a.Name == "Mazda"), AlbumArtUrl = "/Content/Images/Bolt/mmx5rf_roadster.png",Front="/content/Images/Details/Mazdamx5rf-roadster/mazdamx5rf-front.png",Back="/content/Images/Details/Mazdamx5rf-roadster/mazdamx5rf-back.png",Engine="/content/Images/Details/Mazdamx5rf-roadster/mazdamx5rf-engine.png",Interior="/content/Images/Details/Mazdamx5rf-roadster/mazdamx5rf-interior.png"  },
                new Album { Title = "Mazda RX-8", Genre = genres.Single(g => g.Name == "Roadster"), Price = 50000M, Artist = artists.Single(a => a.Name == "Mazda"), AlbumArtUrl = "/Content/Images/Bolt/mrx8_roadster.png",Front="/content/Images/Details/Mazdarx8-roadster/mazdarx8-front.png",Back="/content/Images/Details/Mazdarx8-roadster/mazdarx8-back.png",Engine="/content/Images/Details/Mazdarx8-roadster/mazdarx8-engine.png",Interior="/content/Images/Details/Mazdarx8-roadster/mazdarx8-interior.png"  },
                new Album { Title = "Mazda B-Series", Genre = genres.Single(g => g.Name == "Pickup"), Price = 2900M, Artist = artists.Single(a => a.Name == "Mazda"), AlbumArtUrl = "/Content/Images/Bolt/mbseries_pickup.png",Front="/content/Images/Details/Mazdabseriesregular/mazdabseriesregular-front.png",Back="/content/Images/Details/Mazdabseriesregular/mazdabseriesregular-back.png",Engine="/content/Images/Details/Mazdabseriesregular/mazdabseriesregular-engine.png",Interior="/content/Images/Details/Mazdabseriesregular/mazdabseriesregular-interior.png"  },
                new Album { Title = "Mazda 5", Genre = genres.Single(g => g.Name == "Minivan"), Price = 18000M, Artist = artists.Single(a => a.Name == "Mazda"), AlbumArtUrl = "/Content/Images/Bolt/m5_minivan.png",Front="/content/Images/Details/Mazda5-minivan/mazda5-front.png",Back="/content/Images/Details/Mazda5-minivan/mazda5-back.png",Engine="/content/Images/Details/Mazda5-minivan/mazda5-engine.png",Interior="/content/Images/Details/Mazda5-minivan/mazda5-interior.png"  }
            }.ForEach(a => context.Albums.Add(a));

            new List<Users>
            {
                new Users { UserName = "Admin",Email="Admin@admin.com", Password = "admin"},
                new Users { UserName = "Niko",Email="nikolaszkatona@gmail.com", Password = "niko"},
                new Users { UserName = "Dani",Email="danees1997@gmail.com", Password = "dani"}
            }.ForEach(u => context.Users.Add(u));
        }
        
    }
}