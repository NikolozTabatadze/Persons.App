using Microsoft.EntityFrameworkCore;
using Persons_App.Domain.Entities;
using Persons_App.Infrastrucute.Mappings;


namespace Persons_App.Infrastructure.Context
{
    public class PersonsDBContext : DbContext
    {
        

        public PersonsDBContext(DbContextOptions<PersonsDBContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PersonMap());
            builder.ApplyConfiguration(new RelatedPersonMap());
            base.OnModelCreating(builder);
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<RelatedPerson> RelatedPersons { get; set; }
    }
       
}

