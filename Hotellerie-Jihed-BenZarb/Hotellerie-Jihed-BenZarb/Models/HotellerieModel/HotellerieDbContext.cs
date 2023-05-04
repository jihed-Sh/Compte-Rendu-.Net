using Microsoft.EntityFrameworkCore;

namespace Hotellerie_Jihed_BenZarb.Models.HotellerieModel;

public class HotellerieDbContext : DbContext
{
    public HotellerieDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Hotel> Hotels { get; set; } = null!;
    public DbSet<Appreciation> Appreciations { get; set; } = null!;

}