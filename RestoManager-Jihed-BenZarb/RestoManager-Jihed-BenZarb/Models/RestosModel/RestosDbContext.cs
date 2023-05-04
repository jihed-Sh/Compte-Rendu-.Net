using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestoManager_Jihed_BenZarb.Models.RestosModel;

public partial class RestosDbContext :DbContext
{
    public RestosDbContext(DbContextOptions options) : base(options)
    {
    }
    public virtual DbSet<Restaurant> Restaurants { get; set; }

    public virtual DbSet<Proprietaire> Proprietaires { get; set; }
    public DbSet<Avis>? Avis { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        EntityTypeBuilder<Proprietaire> PropBuilder = modelBuilder.Entity<Proprietaire>();
        PropBuilder.ToTable("TProprietaire");
        PropBuilder.HasKey(p=>p.Numero);
        PropBuilder.Property(p => p.Nom)
            .HasColumnName("NomProp")
            .HasMaxLength(20)
            .IsRequired();
        PropBuilder.Property(p => p.Email)
            .HasColumnName("EmailProp")
            .HasMaxLength(50)
            .IsRequired();
        PropBuilder.Property(p => p.Gsm)
            .HasColumnName("GsmProp")
            .HasMaxLength(8)
            .IsRequired();
        PropBuilder
            .HasMany<Restaurant>(p=>p.LesRestos)
            .WithOne(r=>r.LeProprio)
            .HasForeignKey(r=>r.NumProp)
            .HasConstraintName("Relation_Proprio_Restos")
            .IsRequired();
        
        
        EntityTypeBuilder<Restaurant> RestoBuilder = modelBuilder.Entity<Restaurant>();
        RestoBuilder.ToTable("TRestaurant");
        RestoBuilder.HasKey(r=>r.CodeResto);
        RestoBuilder.Property(r => r.NomResto)
            .HasMaxLength(20)
            .IsRequired();
        RestoBuilder.Property(r => r.Specialite)
            .HasColumnName("SpecResto")
            .HasMaxLength(20)
            .IsRequired()
            .HasDefaultValue("Tunisienne");
        RestoBuilder.Property(r => r.Ville)
            .HasColumnName("VilleResto")
            .HasMaxLength(20)
            .IsRequired();
        RestoBuilder.Property(r => r.Tel)
            .HasColumnName("TelResto")
            .HasMaxLength(8)
            .IsRequired();
        EntityTypeBuilder<Avis> AvisBuilder = modelBuilder.Entity<Avis>();
        RestoBuilder.ToTable("TAvis", "admin");
        AvisBuilder.HasKey(av => av.CodeAvis);
        AvisBuilder.Property(av => av.NomPersonne).HasMaxLength(30).IsRequired();
        AvisBuilder.Property(av => av.Note).IsRequired();
        AvisBuilder.Property(av => av.Commentaire).HasMaxLength(256);
        AvisBuilder.HasOne(r => r.LeResto).WithMany(av => av.LesAvis).HasForeignKey(av => av.NumResto).HasConstraintName("Relation_Resto_Avis").IsRequired();
        
    }
}