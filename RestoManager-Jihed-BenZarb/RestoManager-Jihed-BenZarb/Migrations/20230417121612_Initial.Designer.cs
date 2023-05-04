﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestoManager_Jihed_BenZarb.Models.RestosModel;

#nullable disable

namespace RestoManager_Jihed_BenZarb.Migrations
{
    [DbContext(typeof(RestosDbContext))]
    [Migration("20230417121612_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("RestoManager_Jihed_BenZarb.Models.RestosModel.Proprietaire", b =>
                {
                    b.Property<int>("Numero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("EmailProp");

                    b.Property<string>("Gsm")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)")
                        .HasColumnName("GsmProp");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("NomProp");

                    b.HasKey("Numero");

                    b.ToTable("TProprietaire", (string)null);
                });

            modelBuilder.Entity("RestoManager_Jihed_BenZarb.Models.RestosModel.Restaurant", b =>
                {
                    b.Property<int>("CodeResto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NomResto")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("NumProp")
                        .HasColumnType("int");

                    b.Property<string>("Specialite")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasDefaultValue("Tunisienne")
                        .HasColumnName("SpecResto");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)")
                        .HasColumnName("TelResto");

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("VilleResto");

                    b.HasKey("CodeResto");

                    b.HasIndex("NumProp");

                    b.ToTable("TRestaurant", (string)null);
                });

            modelBuilder.Entity("RestoManager_Jihed_BenZarb.Models.RestosModel.Restaurant", b =>
                {
                    b.HasOne("RestoManager_Jihed_BenZarb.Models.RestosModel.Proprietaire", "LeProprio")
                        .WithMany("LesRestos")
                        .HasForeignKey("NumProp")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Relation_Proprio_Restos");

                    b.Navigation("LeProprio");
                });

            modelBuilder.Entity("RestoManager_Jihed_BenZarb.Models.RestosModel.Proprietaire", b =>
                {
                    b.Navigation("LesRestos");
                });
#pragma warning restore 612, 618
        }
    }
}
