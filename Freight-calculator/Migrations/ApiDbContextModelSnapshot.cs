﻿// <auto-generated />
using System;
using Freight_calculator.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Freight_calculator.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Freight_calculator.Models.Delivery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AuctionGPSPointId")
                        .HasColumnType("int");

                    b.Property<string>("AuctionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("DeliveryCost")
                        .HasColumnType("float");

                    b.Property<int?>("DestinationGPSPointId")
                        .HasColumnType("int");

                    b.Property<bool?>("Dilivered")
                        .HasColumnType("bit");

                    b.Property<double?>("DistanceInKm")
                        .HasColumnType("float");

                    b.Property<double?>("FixedCosts")
                        .HasColumnType("float");

                    b.Property<double?>("Tariff")
                        .HasColumnType("float");

                    b.Property<bool>("VerboseMode")
                        .HasColumnType("bit");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuctionGPSPointId");

                    b.HasIndex("DestinationGPSPointId");

                    b.ToTable("Deliveries");
                });

            modelBuilder.Entity("Freight_calculator.Models.Point2D", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("X")
                        .HasColumnType("float");

                    b.Property<double>("Y")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("GPSPoints");
                });

            modelBuilder.Entity("Freight_calculator.Models.Delivery", b =>
                {
                    b.HasOne("Freight_calculator.Models.Point2D", "AuctionGPSPoint")
                        .WithMany()
                        .HasForeignKey("AuctionGPSPointId");

                    b.HasOne("Freight_calculator.Models.Point2D", "DestinationGPSPoint")
                        .WithMany()
                        .HasForeignKey("DestinationGPSPointId");

                    b.Navigation("AuctionGPSPoint");

                    b.Navigation("DestinationGPSPoint");
                });
#pragma warning restore 612, 618
        }
    }
}
