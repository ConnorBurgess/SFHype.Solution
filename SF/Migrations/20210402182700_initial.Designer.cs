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
    [Migration("20210402182700_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("SFHype.Models.Shop", b =>
                {
                    b.Property<int>("ShopID")
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

                    b.HasKey("ShopID");

                    b.ToTable("Shops");
                });
#pragma warning restore 612, 618
        }
    }
}