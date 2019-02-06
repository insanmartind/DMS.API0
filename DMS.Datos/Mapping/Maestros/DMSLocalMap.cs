using DMS.Entidades.Maestros;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Datos.Mapping.Maestros
{
    public class DMSLocalMap : IEntityTypeConfiguration<DMSLocal>
    {
        public void Configure(EntityTypeBuilder<DMSLocal> builder)
        {
            builder.ToTable("DMSLocal").HasKey(c => c.DMSLocalID);
            builder.Property(c => c.DMSLocalName).HasMaxLength(250);
            builder.Property(c => c.DMSLocalActive).HasColumnType("int");
        }
    }
}
