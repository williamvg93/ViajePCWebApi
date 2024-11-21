using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class JourneyConf : IEntityTypeConfiguration<Journey>
    {
        public void Configure(EntityTypeBuilder<Journey> builder)
        {
            // Table Name
            builder.ToTable("Journey");

            // Assign Primary Key
            builder.HasKey(p => p.Id)
            .HasName("JourneyPK");
            
            builder.Property(p => p.Id)
            .ValueGeneratedOnAdd(); // Assign Automatic Value

            //Defining Fielnd and their Properties
            builder.Property(p => p.Origin)
            .HasMaxLength(50)
            .IsRequired(); // Required Value

            builder.Property(p => p.Destination)
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(p => p.Price)
            .IsRequired();
        }
    }
}