﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PokemonTutorial.Data;

#nullable disable

namespace PokemonTutorial.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PokemonTutorial.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("PokemonTutorial.Models.Country", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("PokemonTutorial.Models.Owner", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CountryID")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gym")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CountryID");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("PokemonTutorial.Models.Pokemon", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Pokemon");
                });

            modelBuilder.Entity("PokemonTutorial.Models.PokemonCategory", b =>
                {
                    b.Property<int>("PokemonID")
                        .HasColumnType("int");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.HasKey("PokemonID", "CategoryID");

                    b.HasIndex("CategoryID");

                    b.ToTable("PokemonCategories");
                });

            modelBuilder.Entity("PokemonTutorial.Models.PokemonOwner", b =>
                {
                    b.Property<int>("PokemonID")
                        .HasColumnType("int");

                    b.Property<int>("OwnerID")
                        .HasColumnType("int");

                    b.HasKey("PokemonID", "OwnerID");

                    b.HasIndex("OwnerID");

                    b.ToTable("PokemonOwners");
                });

            modelBuilder.Entity("PokemonTutorial.Models.Review", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("PokemonID")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("ReviewerID")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("PokemonID");

                    b.HasIndex("ReviewerID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("PokemonTutorial.Models.Reviewer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Reviewers");
                });

            modelBuilder.Entity("PokemonTutorial.Models.Owner", b =>
                {
                    b.HasOne("PokemonTutorial.Models.Country", "Country")
                        .WithMany("Owner")
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("PokemonTutorial.Models.PokemonCategory", b =>
                {
                    b.HasOne("PokemonTutorial.Models.Category", "Category")
                        .WithMany("PokemonCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PokemonTutorial.Models.Pokemon", "Pokemon")
                        .WithMany("PokemonCategories")
                        .HasForeignKey("PokemonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("PokemonTutorial.Models.PokemonOwner", b =>
                {
                    b.HasOne("PokemonTutorial.Models.Owner", "Owner")
                        .WithMany("PokemonOwners")
                        .HasForeignKey("OwnerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PokemonTutorial.Models.Pokemon", "Pokemon")
                        .WithMany("PokemonOwners")
                        .HasForeignKey("PokemonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("PokemonTutorial.Models.Review", b =>
                {
                    b.HasOne("PokemonTutorial.Models.Pokemon", "Pokemon")
                        .WithMany("Reviews")
                        .HasForeignKey("PokemonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PokemonTutorial.Models.Reviewer", "Reviewer")
                        .WithMany("Reviews")
                        .HasForeignKey("ReviewerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokemon");

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("PokemonTutorial.Models.Category", b =>
                {
                    b.Navigation("PokemonCategories");
                });

            modelBuilder.Entity("PokemonTutorial.Models.Country", b =>
                {
                    b.Navigation("Owner");
                });

            modelBuilder.Entity("PokemonTutorial.Models.Owner", b =>
                {
                    b.Navigation("PokemonOwners");
                });

            modelBuilder.Entity("PokemonTutorial.Models.Pokemon", b =>
                {
                    b.Navigation("PokemonCategories");

                    b.Navigation("PokemonOwners");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("PokemonTutorial.Models.Reviewer", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
