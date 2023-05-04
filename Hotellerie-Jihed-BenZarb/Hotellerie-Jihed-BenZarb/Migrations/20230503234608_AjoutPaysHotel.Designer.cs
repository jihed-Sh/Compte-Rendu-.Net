﻿// <auto-generated />
using Hotellerie_Jihed_BenZarb.Models.HotellerieModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hotellerie_Jihed_BenZarb.Migrations
{
    [DbContext(typeof(HotellerieDbContext))]
    [Migration("20230503234608_AjoutPaysHotel")]
    partial class AjoutPaysHotel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Hotellerie_Jihed_BenZarb.Models.HotellerieModel.Appreciation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Commentaire")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("NomPers")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Note")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Appreciations");
                });

            modelBuilder.Entity("Hotellerie_Jihed_BenZarb.Models.HotellerieModel.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Etoiles")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Pays")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SiteWeb")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("Hotellerie_Jihed_BenZarb.Models.HotellerieModel.Appreciation", b =>
                {
                    b.HasOne("Hotellerie_Jihed_BenZarb.Models.HotellerieModel.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });
#pragma warning restore 612, 618
        }
    }
}
