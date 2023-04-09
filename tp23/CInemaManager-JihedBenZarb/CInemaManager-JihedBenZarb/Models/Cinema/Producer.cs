using System;
using System.Collections.Generic;

namespace CInemaManager_JihedBenZarb.Models.Cinema;

public partial class Producer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Nationality { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; } = new List<Movie>();
}
