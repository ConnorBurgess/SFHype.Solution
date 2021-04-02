﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SFHype.Models;

namespace SFHype.Migrations
{
    [DbContext(typeof(ShopContext))]
    [Migration("20210402190303_ShopTypeProp")]
    partial class ShopTypeProp
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("SFHype.Models.Shop", b =>
                {
                    b.Property<int>("ShopId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Describe")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Hype")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("Originated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ShopId");

                    b.ToTable("Shops");

                    b.HasData(
                        new
                        {
                            ShopId = -2,
                            Describe = "A cool shop.",
                            Hype = 0,
                            Name = "SF Shop 1",
                            Originated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ShopId = -1,
                            Describe = "Another cool shop.",
                            Hype = 0,
                            Name = "SF Shop 2",
                            Originated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
