using ASP261103.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP261103.Data;

public static class SeedDatabase
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using ApplicationDbContext _context = new(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

        if (_context.Books.Any()) return;

        _context.Books.AddRange(
            new Book //01
            {
                Title = "A Gyűrűk Ura: A gyűrű szövetsége",
                Author = "J. R. R. Tolkien",
                ISBN = "978-963-307-849-5",
                PublicationYear = 1954,
                PageCount = 423,
                Genre = "Fantasy",
                Description = "Frodó, a hobbit útra kel, hogy elpusztítsa a Sötét Úr, Szauron Egy Gyűrűjét, és ezzel megmentse Középföldét.",
                Price = 4990,
                IsAvilable = true,
                CoverImageUrl = "https://example.com/images/lotr1.jpg",
                CreatedAt = DateTime.UtcNow
            },
        new Book //02
        {
            Title = "Tiszta kód (Clean Code)",
            Author = "Robert C. Martin",
            ISBN = "978-963-997-362-0",
            PublicationYear = 2008,
            PageCount = 464,
            Genre = "Informatika / Programozás",
            Description = "A szoftverfejlesztés egyik legfontosabb alapműve, amely a karbantartható és olvasható kód írásának művészetét tanítja meg.",
            Price = 8500,
            IsAvilable = true,
            CoverImageUrl = "https://example.com/images/cleancode.jpg",
            CreatedAt = DateTime.UtcNow.AddDays(-2)
        },
        new Book //03
        {
            Title = "Dűne",
            Author = "Frank Herbert",
            ISBN = "978-963-307-593-7",
            PublicationYear = 1965,
            PageCount = 512,
            Genre = "Sci-fi",
            Description = "Paul Atreides története az Arrakis sivatagbolygón, ahol a legértékesebb kincs a fűszer. A science fiction irodalom egyik legnagyobb klasszikusa.",
            Price = 5200,
            IsAvilable = false,
            CoverImageUrl = "https://example.com/images/dune.jpg",
            CreatedAt = DateTime.UtcNow.AddHours(-5)
        });
        _context.SaveChanges();

    }
}
