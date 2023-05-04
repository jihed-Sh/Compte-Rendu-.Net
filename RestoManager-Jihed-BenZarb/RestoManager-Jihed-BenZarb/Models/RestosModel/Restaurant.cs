namespace RestoManager_Jihed_BenZarb.Models.RestosModel;

public partial class Restaurant
{
    public int CodeResto { get; set; }
    public String NomResto { get; set; }= null!;
    public String Specialite { get; set; } = null!;
    public String Ville { get; set; }= null!;
    public String Tel { get; set; }= null!;
    public int NumProp { get; set; }
    public virtual Proprietaire LeProprio { get; set; } = null!;
    public virtual ICollection<Avis>? LesAvis { get; set; }
}