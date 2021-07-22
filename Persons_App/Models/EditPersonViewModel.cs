
using PersonsApp.EntityFrameworkCore.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace PersonsApp.Models
{
    public class EditPersonViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        [Required]
        [StringLength(11)]
        public string PmNumber { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public City City { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        public PhoneNumberType PhoneNumberType { get; set; }
    }
}
