
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persons_App.Domain.Entities;
namespace Persons_App.Infrastrucute.Mappings
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
