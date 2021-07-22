using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonsApp.EntityFrameworkCore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsApp.EntityFrameworkCore.Data.Mappings
{
    public class RelatedPersonMap : IEntityTypeConfiguration<RelatedPerson>
    {
        public void Configure(EntityTypeBuilder<RelatedPerson> entity)
        {
            entity.ToTable("RelatedPerson");
            entity.HasKey(t => t.Id);
            entity.Property(t => t.PersonId).HasColumnName("PersonId").IsRequired();
            entity.Property(t => t.RelatedPersonId).HasColumnName("RelatedPersonId").IsRequired();
            entity.Property(t => t.RelationType).HasColumnName("RelationType").IsRequired();

        }
    }
}
