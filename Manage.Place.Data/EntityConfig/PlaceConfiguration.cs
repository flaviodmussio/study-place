using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Manage.Place.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Manage.Place.Domain.Enums;

namespace Manage.Place.Data.EntityConfig
{
    public class PlaceConfiguration : IEntityTypeConfiguration<Places>
    {
        public void Configure(EntityTypeBuilder<Places> builder)
        {

            builder.ToTable("T001_Place");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("ID");

            builder.Property(x => x.PlaceName)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.PlaceCity)
                .HasColumnName("CIDADE")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.PlaceState)
                .HasColumnName("ESTADO")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.PlaceSlug)
                .HasColumnName("SLUG")
                .HasMaxLength(200)
                .IsRequired();

            builder
               .Property(x => x.DateCreated)
               .HasColumnName("DT_CRCO")
               .IsRequired();

            builder
                .Property(x => x.DateUpdated)
                .HasColumnName("DT_ATLCO");

            builder
                .Property(x => x.Status)
                .HasConversion(x => x.ToString(), x => (EEntityStatus)Enum.Parse(typeof(EEntityStatus), x))
                .HasColumnName("IC_STATUS")
                .HasMaxLength(20)
                .IsRequired();


            builder
                .HasQueryFilter(p => p.Status == EEntityStatus.Active);
        }
    }
}
