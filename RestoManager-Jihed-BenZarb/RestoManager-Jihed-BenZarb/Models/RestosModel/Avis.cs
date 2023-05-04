using System.ComponentModel.DataAnnotations;

namespace RestoManager_Jihed_BenZarb.Models.RestosModel
{
    public class Avis
    {
        public int CodeAvis { get; set; }
        public string NomPersonne { get; set; }
        [Range(0, 5)]
        public int Note { get; set; }
        public string Commentaire { get; set; }
        public int NumResto { get; set; }
        public virtual Restaurant? LeResto { get; set; }
    }
}
