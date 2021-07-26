using Persons_App.Application.ViewModels;
using Persons_App.Domain.Entities;
using System.Collections.Generic;

namespace Persons_App.Application.Interfaces
{
    public interface IPersonService
    {
        IEnumerable<Person> GetPersons();
        Person GetPersonById(int Id);
        Person UpdatePerson(Person model);
        void CreatePerson(Person model);
        void DeletePerson(int Id);
        IEnumerable<Person> SearchPerson(string searchTerm);
        void SaveChanges();


    }
}
