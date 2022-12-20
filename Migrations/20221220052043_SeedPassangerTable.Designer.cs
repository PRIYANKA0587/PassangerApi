﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PassangerApi.DataContext;

#nullable disable

namespace PassangerApi.Migrations
{
    [DbContext(typeof(PassangerDbContext))]
    [Migration("20221220052043_SeedPassangerTable")]
    partial class SeedPassangerTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PassangerApi.Models.Passanger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adhar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Passangers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adhar = "433454657612",
                            Age = 30,
                            CreatedDate = new DateTime(2022, 12, 20, 10, 50, 43, 136, DateTimeKind.Local).AddTicks(1555),
                            Email = "sobarp@gmail.com",
                            MobileNumber = "656095445",
                            Name = "Priyanka",
                            UpdatedDate = new DateTime(2022, 12, 20, 10, 50, 43, 136, DateTimeKind.Local).AddTicks(1566)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
