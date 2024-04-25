﻿// <auto-generated />
using System;
using MayTheFourth.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MayTheFourth.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FilmCharacter", b =>
                {
                    b.Property<Guid>("FilmCharacter")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FilmId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FilmCharacter", "FilmId");

                    b.HasIndex("FilmId");

                    b.ToTable("FilmCharacter");
                });

            modelBuilder.Entity("FilmPlanet", b =>
                {
                    b.Property<Guid>("FilmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FilmPlanet")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FilmId", "FilmPlanet");

                    b.HasIndex("FilmPlanet");

                    b.ToTable("FilmPlanet");
                });

            modelBuilder.Entity("FilmSpecies", b =>
                {
                    b.Property<Guid>("FilmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SpeciesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FilmId", "SpeciesId");

                    b.HasIndex("SpeciesId");

                    b.ToTable("FilmSpecies");
                });

            modelBuilder.Entity("FilmStarship", b =>
                {
                    b.Property<Guid>("FilmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StarshipId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FilmId", "StarshipId");

                    b.HasIndex("StarshipId");

                    b.ToTable("FilmStarship");
                });

            modelBuilder.Entity("FilmVehicle", b =>
                {
                    b.Property<Guid>("FilmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VehicleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FilmId", "VehicleId");

                    b.HasIndex("VehicleId");

                    b.ToTable("FilmVehicle");
                });

            modelBuilder.Entity("MayTheFourth.Core.Entities.Film", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("DATETIME")
                        .HasColumnName("Created");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasMaxLength(160)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Director");

                    b.Property<DateTime>("Edited")
                        .HasColumnType("DATETIME")
                        .HasColumnName("Edited");

                    b.Property<int>("EpisodeId")
                        .HasColumnType("INT")
                        .HasColumnName("EpisodeId");

                    b.Property<string>("OpeningCrawl")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("OpeningCrawl");

                    b.Property<string>("Producer")
                        .IsRequired()
                        .HasMaxLength(160)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Producer");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("DATETIME")
                        .HasColumnName("ReleaseDate");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(160)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Title");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Url");

                    b.HasKey("Id");

                    b.ToTable("Film", (string)null);
                });

            modelBuilder.Entity("MayTheFourth.Core.Entities.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BirthYear")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("BirthYear");

                    b.Property<DateTime>("Created")
                        .HasColumnType("DATETIME")
                        .HasColumnName("Created");

                    b.Property<DateTime>("Edited")
                        .HasColumnType("DATETIME")
                        .HasColumnName("Edited");

                    b.Property<string>("EyeColor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("EyeColor");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Gender");

                    b.Property<string>("HairColor")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("HairColor");

                    b.Property<int>("Height")
                        .HasColumnType("INT")
                        .HasColumnName("Height");

                    b.Property<Guid>("HomeworldId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Mass")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Mass");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Name");

                    b.Property<string>("SkinColor")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("SkinColor");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Url");

                    b.HasKey("Id");

                    b.HasIndex("HomeworldId");

                    b.ToTable("Person", (string)null);
                });

            modelBuilder.Entity("MayTheFourth.Core.Entities.Planet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Climate")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Climate");

                    b.Property<DateTime>("Created")
                        .HasColumnType("DATETIME")
                        .HasColumnName("Created");

                    b.Property<string>("Diameter")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Diameter");

                    b.Property<DateTime>("Edited")
                        .HasColumnType("DATETIME")
                        .HasColumnName("Edited");

                    b.Property<string>("Gravity")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Gravity");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Name");

                    b.Property<string>("OrbitalPeriod")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("OrbitalPeriod");

                    b.Property<string>("Population")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Population");

                    b.Property<string>("RotationPeriod")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("RotationPeriod");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurfaceWater")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("SurfaceWater");

                    b.Property<string>("Terrain")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Terrain");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Url");

                    b.HasKey("Id");

                    b.ToTable("Planets", (string)null);
                });

            modelBuilder.Entity("MayTheFourth.Core.Entities.Species", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AverageHeight")
                        .HasColumnType("INT")
                        .HasColumnName("AverageHeight");

                    b.Property<int>("AverageLifespan")
                        .HasColumnType("INT")
                        .HasColumnName("AverageLifespan");

                    b.Property<string>("Classification")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Classification");

                    b.Property<DateTime>("Created")
                        .HasColumnType("DATETIME")
                        .HasColumnName("Created");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Designation");

                    b.Property<DateTime>("Edited")
                        .HasColumnType("DATETIME")
                        .HasColumnName("Edited");

                    b.Property<string>("EyeColors")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("EyeColors");

                    b.Property<string>("HairColors")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("HairColors");

                    b.Property<Guid?>("HomeworldId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Language");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Name");

                    b.Property<string>("SkinColors")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("SkinColors");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Url");

                    b.HasKey("Id");

                    b.HasIndex("HomeworldId");

                    b.ToTable("Species", (string)null);
                });

            modelBuilder.Entity("MayTheFourth.Core.Entities.Starship", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CargoCapacity")
                        .HasColumnType("INT")
                        .HasColumnName("CargoCapacity");

                    b.Property<string>("Consumables")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Consumables");

                    b.Property<int>("CostInCredits")
                        .HasColumnType("INT")
                        .HasColumnName("CostInCredits");

                    b.Property<DateTime>("Created")
                        .HasColumnType("DATETIME")
                        .HasColumnName("Created");

                    b.Property<int>("Crew")
                        .HasColumnType("INT")
                        .HasColumnName("Crew");

                    b.Property<DateTime>("Edited")
                        .HasColumnType("DATETIME")
                        .HasColumnName("Edited");

                    b.Property<string>("HyperdriveRating")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("HyperdriveRating");

                    b.Property<decimal>("Length")
                        .HasColumnType("DECIMAL")
                        .HasColumnName("Length");

                    b.Property<string>("MGLT")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("MGLT");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Manufacturer");

                    b.Property<int>("MaxAtmospheringSpeed")
                        .HasColumnType("INT")
                        .HasColumnName("MaxAtmospheringSpeed");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Model");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Name");

                    b.Property<int>("Passengers")
                        .HasColumnType("INT")
                        .HasColumnName("Passengers");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StarshipClass")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("StarshipClass");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARChAR")
                        .HasColumnName("Url");

                    b.HasKey("Id");

                    b.ToTable("Starships", (string)null);
                });

            modelBuilder.Entity("MayTheFourth.Core.Entities.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CargoCapacity")
                        .HasColumnType("INT")
                        .HasColumnName("CargoCapacity");

                    b.Property<string>("Consumables")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Consumables");

                    b.Property<decimal>("CostInCredits")
                        .HasColumnType("DECIMAL")
                        .HasColumnName("CostInCredits");

                    b.Property<DateTime>("Created")
                        .HasColumnType("DATETIME")
                        .HasColumnName("Created");

                    b.Property<string>("Crew")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Crew");

                    b.Property<DateTime>("Edited")
                        .HasColumnType("DATETIME")
                        .HasColumnName("Edited");

                    b.Property<int>("Length")
                        .HasColumnType("INT")
                        .HasColumnName("Length");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Manufacturer");

                    b.Property<int>("MaxAtmospheringSpeed")
                        .HasColumnType("INT")
                        .HasColumnName("MaxAtmospheringSpeed");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Model");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Name");

                    b.Property<string>("Passengers")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Passengers");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Url");

                    b.Property<string>("VehicleClass")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NVARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Vehicles", (string)null);
                });

            modelBuilder.Entity("PersonSpecies", b =>
                {
                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SpeciesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PersonId", "SpeciesId");

                    b.HasIndex("SpeciesId");

                    b.ToTable("PersonSpecies");
                });

            modelBuilder.Entity("PersonStarship", b =>
                {
                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StarshipId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PersonId", "StarshipId");

                    b.HasIndex("StarshipId");

                    b.ToTable("PersonStarship");
                });

            modelBuilder.Entity("PersonVehicle", b =>
                {
                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VehicleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PersonId", "VehicleId");

                    b.HasIndex("VehicleId");

                    b.ToTable("PersonVehicle");
                });

            modelBuilder.Entity("FilmCharacter", b =>
                {
                    b.HasOne("MayTheFourth.Core.Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("FilmCharacter")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MayTheFourth.Core.Entities.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FilmPlanet", b =>
                {
                    b.HasOne("MayTheFourth.Core.Entities.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MayTheFourth.Core.Entities.Planet", null)
                        .WithMany()
                        .HasForeignKey("FilmPlanet")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FilmSpecies", b =>
                {
                    b.HasOne("MayTheFourth.Core.Entities.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MayTheFourth.Core.Entities.Species", null)
                        .WithMany()
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FilmStarship", b =>
                {
                    b.HasOne("MayTheFourth.Core.Entities.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MayTheFourth.Core.Entities.Starship", null)
                        .WithMany()
                        .HasForeignKey("StarshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FilmVehicle", b =>
                {
                    b.HasOne("MayTheFourth.Core.Entities.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MayTheFourth.Core.Entities.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MayTheFourth.Core.Entities.Person", b =>
                {
                    b.HasOne("MayTheFourth.Core.Entities.Planet", "Homeworld")
                        .WithMany("Residents")
                        .HasForeignKey("HomeworldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Homeworld");
                });

            modelBuilder.Entity("MayTheFourth.Core.Entities.Species", b =>
                {
                    b.HasOne("MayTheFourth.Core.Entities.Planet", "Homeworld")
                        .WithMany()
                        .HasForeignKey("HomeworldId");

                    b.Navigation("Homeworld");
                });

            modelBuilder.Entity("PersonSpecies", b =>
                {
                    b.HasOne("MayTheFourth.Core.Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MayTheFourth.Core.Entities.Species", null)
                        .WithMany()
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("PersonStarship", b =>
                {
                    b.HasOne("MayTheFourth.Core.Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MayTheFourth.Core.Entities.Starship", null)
                        .WithMany()
                        .HasForeignKey("StarshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PersonVehicle", b =>
                {
                    b.HasOne("MayTheFourth.Core.Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MayTheFourth.Core.Entities.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MayTheFourth.Core.Entities.Planet", b =>
                {
                    b.Navigation("Residents");
                });
#pragma warning restore 612, 618
        }
    }
}
