using System.ComponentModel.DataAnnotations;

namespace Hotellerie_Jihed_BenZarb.Models.HotellerieModel;

public class Hotel
{
    public int Id { get; set; }
    [Required(ErrorMessage ="Champ obligatoire")]
    [StringLength(20,MinimumLength=3,ErrorMessage ="Longueur entre 3 et 20")]
    public string Nom { get; set; } = null!;
    [Range(1,5,ErrorMessage ="champ valant de 1 à 5")]
    public int Etoiles { get; set; }
    [Required(ErrorMessage = "Champ obligatoire")]
    public string Ville { get; set; } = null!;
    [Required(ErrorMessage = "Champ obligatoire")]
    [Url]
    public string SiteWeb { get; set; } = null!;
    public string Tel { get; set; } = null!;
    public string Pays { get; set; } = null!;
}