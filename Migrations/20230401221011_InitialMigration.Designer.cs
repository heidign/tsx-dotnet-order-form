﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using tsx_react_project.Models;

namespace tsx_react_project.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230401221011_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("stoneid")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("stoneid");

                    b.ToTable("JewelryPieces");
                });

            modelBuilder.Entity("tsx_react_project.Stone", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("shape")
                        .HasColumnType("integer");

                    b.Property<int>("type")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("Cabs");
                });

            modelBuilder.Entity("tsx_react_project.Models.Jewelry", b =>
                {
                    b.HasOne("tsx_react_project.Stone", "stone")
                        .WithMany()
                        .HasForeignKey("stoneid");

                    b.Navigation("stone");
                });
#pragma warning restore 612, 618
        }
    }
}
