using Persons_App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons_App.Application.ViewModels
{
    public class PersonViewModel
    {
        public IEnumerable<Person> Persons { get; set; }
    }
}
