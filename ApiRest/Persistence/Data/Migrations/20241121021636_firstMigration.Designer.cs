﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.data;

#nullable disable

namespace Persistence.Data.Migrations
{
    [DbContext(typeof(ApiVpContext))]
    [Migration("20241121021636_firstMigration")]
    partial class firstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entity.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("JourneyId")
                        .HasColumnType("int");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<int>("TansportIDFk")
                        .HasColumnType("int")
                        .HasColumnName("fk_IdTrasport");

                    b.HasKey("Id")
                        .HasName("FlightPK");

                    b.HasIndex("JourneyId");

                    b.HasIndex("TansportIDFk");

                    b.ToTable("Flight", (string)null);
                });

            modelBuilder.Entity("Domain.Entity.Journey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.HasKey("Id")
                        .HasName("JourneyPK");

                    b.ToTable("Journey", (string)null);
                });

            modelBuilder.Entity("Domain.Entity.Transport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FlightCarrier")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FlightNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("TransportPK");

                    b.ToTable("Transport", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FlightCarrier = "Avianca",
                            FlightNumber = "100001"
                        });
                });

            modelBuilder.Entity("Domain.Entity.Flight", b =>
                {
                    b.HasOne("Domain.Entity.Journey", null)
                        .WithMany("Flights")
                        .HasForeignKey("JourneyId");

                    b.HasOne("Domain.Entity.Transport", "Transport")
                        .WithMany("Flights")
                        .HasForeignKey("TansportIDFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Transport");
                });

            modelBuilder.Entity("Domain.Entity.Journey", b =>
                {
                    b.Navigation("Flights");
                });

            modelBuilder.Entity("Domain.Entity.Transport", b =>
                {
                    b.Navigation("Flights");
                });
#pragma warning restore 612, 618
        }
    }
}