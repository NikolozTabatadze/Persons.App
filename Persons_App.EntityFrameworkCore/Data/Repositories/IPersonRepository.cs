using PersonsApp.EntityFrameworkCore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsApp.EntityFrameworkCore.Data.Repositories
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAllPersons();
        IEnumerable<Person> GetPersonById(int Id);
        IEnumerable<Person> UpdatePerson(Person model);
        void DeletePerson(int Id);
        void CreatePerson(Person model);
        void SaveChanges();
    }
}
