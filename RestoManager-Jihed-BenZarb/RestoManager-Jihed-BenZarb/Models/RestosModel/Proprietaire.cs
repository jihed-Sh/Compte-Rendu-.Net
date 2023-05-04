namespace RestoManager_Jihed_BenZarb.Models.RestosModel;

public partial class Proprietaire
{
    public int Numero { get; set; }
    public String Nom { get; set; }= null!;
    public String Email { get; set; } = null!;
    public String Gsm { get; set; }= null!;
    public virtual ICollection<Restaurant> LesRestos { get; } = new List<Restaurant>();
}