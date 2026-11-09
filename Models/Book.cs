using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP261103.Models;

[Table("books")]
public class Book
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "A cím megadása kötelező!")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "A cím hossza 2 és 50 karakter közt kell legyen!")]
    [Display(Name = "Cím")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "A szerző megadása kötelező!")]
    [StringLength(50, ErrorMessage = "A szerző neve maximum 100 karakter lehet!")]
    [Display(Name = "Szerző")]
    public string Author { get; set; } = string.Empty;

    [Required(ErrorMessage = "Az ISBM szám megadása kötelező!")]
    // https://regex101.com/
    [RegularExpression("^(?=(?:[^0-9]*[0-9]){10}(?:(?:[^0-9]*[0-9]){3})?$)[\\d-]+$", ErrorMessage = "Érvénytelen ISBN formátum")]
    public string ISBN { get; set; } = string.Empty;

    [Range(1450, 2100, ErrorMessage = "Adj meg egy érvényes kiadási évet!")]
    [Display(Name = "Kiadás éve")]
    public int PublicationYear { get; set; }

    [Range(1, 10000, ErrorMessage = "Az oldalászámnak 1 és 10 000 között kell lennie!")]
    [Display (Name = "Oldalászám")]
    public int PageCount { get; set; }
    
    [StringLength(50)]
    [Display(Name = "Műfaj")]
    public string? Genre { get; set; }

    [DataType(DataType.MultilineText)]
    [StringLength(2000, ErrorMessage = "A leírás nem lehet hosszabb 2000 karakternél!")]
    [Display(Name = "Rövid leírás")]
    public string? Description { get; set; }

    [Range(0, 1000000, ErrorMessage = "Az ár nem lehet negatív!")]
    [DisplayFormat(DataFormatString = "{0:C0}")]
    public int Price { get; set; }
    [Display(Name = "Készleten")]
    [ValidateNever]
    public bool IsAvilable { get; set; } = true;

    [Url(ErrorMessage = "Érvénytelen URL formátum!")]
    [Display(Name = "Borítókép URL")]
    public string? CoverImageUrl { get; set; }

    [DataType(DataType.DateTime)]
    [Display(Name = "Rögzítés dátuma")]
    [ValidateNever]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
