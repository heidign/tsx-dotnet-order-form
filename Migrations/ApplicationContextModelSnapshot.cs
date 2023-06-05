﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using tsx_react_project.Models;

namespace tsx_react_project.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("tsx_react_project.Models.Jewelry", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("material")
                        .HasColumnType("integer");

                    b.Property<int>("piece")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("JewelryPieces");
                });

            modelBuilder.Entity("tsx_react_project.Models.Stone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("JewelryId")
                        .HasColumnType("integer");

                    b.Property<int>("shape")
                        .HasColumnType("integer");

                    b.Property<int>("type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("JewelryId");

                    b.ToTable("Cabs");
                });

            modelBuilder.Entity("tsx_react_project.Models.Stone", b =>
                {
                    b.HasOne("tsx_react_project.Models.Jewelry", null)
                        .WithMany("stones")
                        .HasForeignKey("JewelryId");
                });

            modelBuilder.Entity("tsx_react_project.Models.Jewelry", b =>
                {
                    b.Navigation("stones");
                });
#pragma warning restore 612, 618
        }
    }
}
