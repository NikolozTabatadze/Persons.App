using Persons_App.Application.Interfaces;
using Persons_App.Application.ViewModels;
using Persons_App.Domain.Entities;
using Persons_App.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons_App.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;

        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
        }

        public void CreatePerson(Person model)
        {
            _repository.CreatePerson(model);
        }

        public void DeletePerson(int Id)
        {
            _repository.DeletePerson(Id);
        }

        public Person GetPersonById(int Id)
        {
            return _repository.GetPersonById(Id);
        }

        public IEnumerable<Person> GetPersons()
        {
            return _repository.GetAllPersons().ToList(); 
        }

        public void SaveChanges()
        {
            _repository.SaveChanges();
        }

        public IEnumerable<Person> SearchPerson(string searchTerm)
        {
            return _repository.SearchPerson(searchTerm).ToList();
        }

        public Person UpdatePerson(Person model)
        {
            return _repository.UpdatePerson(model);
        }
    }
}
