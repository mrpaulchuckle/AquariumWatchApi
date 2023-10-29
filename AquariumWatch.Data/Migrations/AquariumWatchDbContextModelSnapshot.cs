﻿// <auto-generated />
using AquariumWatch.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AquariumWatch.Data.Migrations
{
    [DbContext(typeof(AquariumWatchDbContext))]
    partial class AquariumWatchDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AquariumWatch.Data.Entities.Aquarium", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Ammonia")
                        .HasColumnType("double precision");

                    b.Property<double>("HighTemp")
                        .HasColumnType("double precision");

                    b.Property<double>("LowTemp")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Nitrate")
                        .HasColumnType("double precision");

                    b.Property<double>("Nitrite")
                        .HasColumnType("double precision");

                    b.Property<double>("Ph")
                        .HasColumnType("double precision");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Aquariums");
                });
#pragma warning restore 612, 618
        }
    }
}
