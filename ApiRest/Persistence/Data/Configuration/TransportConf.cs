using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class TransportConf : IEntityTypeConfiguration<Transport>
    {
        public void Configure(EntityTypeBuilder<Transport> builder)
        {
            // Table Name
            builder.ToTable("Transport");

            // Assing Primary Key
            builder.HasKey(pk => pk.Id)
            .HasName("TransportPK");

            builder.Property(p => p.Id)
            .ValueGeneratedOnAdd(); // Assign Automatic Value

            // Defining Fields and their properties
            builder.Property(p => p.FlightCarrier)
            .HasMaxLength(50)
            .IsRequired(); // Required value

            builder.HasIndex(p => p.FlightCarrier)
            .IsUnique(); //Unique Field
            
            builder.Property(p => p.FlightNumber)
            .HasMaxLength(50)
            .IsRequired();
        }
    }
}