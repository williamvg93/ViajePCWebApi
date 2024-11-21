using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class FlightConf : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            // Table Name
            builder.ToTable("Flight");

            // Assign Primary Key
            builder.HasKey(pk => pk.Id)
            .HasName("FlightPK");

            builder.Property(p => p.Id)
            .ValueGeneratedOnAdd(); // Assign Automatic Value

            // Defining Fields and their properties
            builder.Property(p => p.Origin)
            .HasMaxLength(50)
            .IsRequired(); //Required value

            builder.Property(p => p.Destination)
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(p => p.Price)
            .IsRequired();

            builder.Property(p => p.TansportIDFk)
            .HasColumnName("fk_IdTrasport")
            .IsRequired();

            // Creating the realtionship
            builder.HasOne(p => p.Transport)
            .WithMany(p => p.Flights)
            .HasForeignKey(fk => fk.TansportIDFk);
        }
    }
}