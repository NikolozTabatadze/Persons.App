using Persons_App.Domain.Entities;
using Persons_App.Domain.Interfaces;
using Persons_App.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Persons_App.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonsDBContext _context;

        public PersonRepository(PersonsDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return _context.Persons
                .OrderBy(p => p.FirstName)
                .ToList();
        }
        public Person GetPersonById(int Id)
        {
            return _context.Persons
                .Where(p => p.Id == Id)
                .FirstOrDefault();
        }

        public Person UpdatePerson(Person model)
        {
            var person = _context.Persons.Where(p => p.Id == model.Id).FirstOrDefault();
            if (person != null)
            {
                person.Id = model.Id;
                person.FirstName = model.FirstName;
                person.LastName = model.LastName;
                person.Gender = model.Gender;
                person.City = model.City;
                person.BirthDate = model.BirthDate;
                person.PhoneNumber = model.PhoneNumber;
                person.PhoneNumberType = model.PhoneNumberType;
                person.PmNumber = model.PmNumber;
            }
            else
            {
                return null;
            }

            return person;
        }

        public void CreatePerson(Person model)
        {
            _context.Persons.Add(model);
        }

        public void DeletePerson(int Id)
        {
            var item = _context.Persons.Where(p => p.Id == Id).FirstOrDefault();
            _context.Persons.Remove(item);
        }
        public void SaveChanges()
        {
          _context.SaveChanges();
        }

        public IEnumerable<Person> SearchPerson(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return _context.Persons.ToList();
            }
            return _context.Persons.Where(x => x.FirstName.Contains(searchTerm) ||
                                               x.LastName.Contains(searchTerm) ||
                                               x.PmNumber.Contains(searchTerm) ||
                                               x.PhoneNumber.Contains(searchTerm)).ToList();
        }
    }
}
