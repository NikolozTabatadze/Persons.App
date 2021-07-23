using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonsApp.EntityFrameworkCore.Data.Entities;
using PersonsApp.EntityFrameworkCore.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonsApp.Page
{
    public class Index:PageModel
    {
        private readonly IPersonRepository _repository;

        public Index(IPersonRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Person> Person { get; set; }

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public void OnGet()
        {
            Person = _repository.SerachPerson(SearchTerm);
        }
    }
}
