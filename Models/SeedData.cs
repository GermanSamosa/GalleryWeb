using Microsoft.EntityFrameworkCore;
using WebGallery.Data;

namespace WebGallery.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebGalleryContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<WebGalleryContext>>()))
            {
                // Look for pieces
                if (context.Piece.Any())
                {
                    return; // DB has been seeded
                }
                context.Piece.AddRange(
                    new Piece
                    {
                        Title = "Test",
                        ReleaseDate = DateTime.Parse("1996-2-23"),
                        Description = "Test",
                        Price = 10,
                        Quantity = 5
                    },
                    new Piece
                    {
                        Title = "Test",
                        ReleaseDate = DateTime.Parse("1996-2-23"),
                        Description = "Test",
                        Price = 10,
                        Quantity = 5
                    },
                    new Piece
                    {
                        Title = "Test",
                        ReleaseDate = DateTime.Parse("1996-2-23"),
                        Description = "Test",
                        Price = 10,
                        Quantity = 5
                    },
                    new Piece
                    {
                        Title = "Test",
                        ReleaseDate = DateTime.Parse("1996-2-23"),
                        Description = "Test",
                        Price = 10,
                        Quantity = 5
                    },
                    new Piece
                    {
                        Title = "Test",
                        ReleaseDate = DateTime.Parse("1996-2-23"),
                        Description = "Test",
                        Price = 10,
                        Quantity = 7
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
