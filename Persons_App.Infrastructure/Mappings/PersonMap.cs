
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persons_App.Domain.Entities;

namespace Persons_App.Infrastrucute.Mappings
{
        public class PersonMap : IEntityTypeConfiguration<Person>
        {
            public void Configure(EntityTypeBuilder<Person> entity)
            {
                entity.ToTable("Person");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.FirstName).HasColumnName("FirstName").IsRequired().HasMaxLength(50);
                entity.Property(t => t.LastName).HasColumnName("LastName").IsRequired().HasMaxLength(50);
                entity.Property(t => t.Gender).HasColumnName("Gender").IsRequired(false);
                entity.Property(t => t.PmNumber).HasColumnName("PmNumber").IsRequired().HasMaxLength(11);
                entity.Property(t => t.BirthDate).HasColumnName("BirthDate").IsRequired();
                entity.Property(t => t.City).HasColumnName("City").IsRequired(false);
                entity.Property(t => t.PhoneNumber).HasColumnName("PhoneNumber").IsRequired().HasMaxLength(50);
                entity.Property(t => t.PhoneNumberType).HasColumnName("PhoneNumberType").IsRequired();
                entity.Property(t => t.Image).HasColumnName("Image").IsRequired(false).HasMaxLength(255);
                entity.HasMany(t => t.RelatedPersons).WithOne(t => t.Person).HasForeignKey(t => t.PersonId);
            }
        }
}
