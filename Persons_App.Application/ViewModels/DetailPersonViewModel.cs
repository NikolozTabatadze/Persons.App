using Persons_App.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons_App.Application.ViewModels
{
    public class DetailPersonViewModel
    {

            public int Id { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public Gender Gender { get; set; }

            public string PmNumber { get; set; }
            public DateTime BirthDate { get; set; }

            public City City { get; set; }
            public string PhoneNumber { get; set; }

            public PhoneNumberType PhoneNumberType { get; set; }

            public string Image { get; set; }
        }
}
