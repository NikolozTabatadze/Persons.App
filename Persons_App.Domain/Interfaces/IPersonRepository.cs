using Persons_App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons_App.Domain.Interfaces
{
    public interface IPersonRepository
    {
        IEnumerable<Person> SearchPerson(string searchTerm);
        IEnumerable<Person> GetAllPersons();
        Person GetPersonById(int Id);
        Person UpdatePerson(Person model);
        void DeletePerson(int Id);
        void CreatePerson(Person model);
        void SaveChanges();
    }
}
