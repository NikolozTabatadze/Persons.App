using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using PersonsApp.EntityFrameworkCore.Data.Entities;
using PersonsApp.EntityFrameworkCore.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsApp.EntityFrameworkCore.Data
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

