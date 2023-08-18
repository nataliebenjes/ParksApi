﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkApi.Models;

#nullable disable

namespace ParkApi.Migrations
{
    [DbContext(typeof(ParkApiContext))]
    partial class ParkApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ParkApi.Models.Park", b =>
                {
                    b.Property<int>("ParkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FoundedIn")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ParkId");

                    b.ToTable("Parks");

                    b.HasData(
                        new
                        {
                            ParkId = 1,
                            FoundedIn = 1932,
                            Name = "Grand Canyon",
                            Type = "National"
                        },
                        new
                        {
                            ParkId = 2,
                            FoundedIn = 1919,
                            Name = "Zion",
                            Type = "National"
                        },
                        new
                        {
                            ParkId = 3,
                            FoundedIn = 1938,
                            Name = "Bryce",
                            Type = "National"
                        },
                        new
                        {
                            ParkId = 4,
                            FoundedIn = 1915,
                            Name = "Rocky Mountain",
                            Type = "National"
                        },
                        new
                        {
                            ParkId = 5,
                            FoundedIn = 1938,
                            Name = "Olympic Penninsula",
                            Type = "National"
                        },
                        new
                        {
                            ParkId = 6,
                            FoundedIn = 1933,
                            Name = "Silver Falls",
                            Type = "State"
                        },
                        new
                        {
                            ParkId = 7,
                            FoundedIn = 1948,
                            Name = "Sunset Bay",
                            Type = "State"
                        },
                        new
                        {
                            ParkId = 8,
                            FoundedIn = 2007,
                            Name = "LL Stub Stewart",
                            Type = "State"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
