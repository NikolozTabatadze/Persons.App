using Microsoft.AspNetCore.Mvc;
using PersonsApp.EntityFrameworkCore.Data.Entities;
using PersonsApp.EntityFrameworkCore.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonsApp.Models
{
    public class PersonIndexViewModel
    {
        public IEnumerable<Person> Persons { get; set; }

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

    }
}
