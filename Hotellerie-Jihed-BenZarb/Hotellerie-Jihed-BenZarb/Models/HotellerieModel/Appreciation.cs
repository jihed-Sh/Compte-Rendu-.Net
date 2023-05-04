using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hotellerie_Jihed_BenZarb.Models.HotellerieModel;

public class Appreciation
{
        [Key]
        public int Id { get; set; }
        [Required,DisplayName("Nom Personne")]
        public string NomPers { get; set; } = null!;
        [Required, DataType(DataType.MultilineText)]
        public string Commentaire { get; set; } = null!;
        
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [Range(1, 5, ErrorMessage = "entre 1 et 5")]
        public int Note { get; set; }
        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; } = null!;
}
