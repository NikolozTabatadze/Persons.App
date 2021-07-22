
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace PersonsApp.EntityFrameworkCore.Data.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender? Gender { get; set; }
        public string PmNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public City? City { get; set; }
        public string PhoneNumber { get; set; }
        public PhoneNumberType PhoneNumberType { get; set; }
        public string Image { get; set; }
        public List<RelatedPerson> RelatedPersons { get; set; }
    }
}
