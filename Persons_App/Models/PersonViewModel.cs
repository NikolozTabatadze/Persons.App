using Microsoft.AspNetCore.Http;
using PersonsApp.EntityFrameworkCore.Data.Entities;
using PersonsApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace Persons_App.Models
{
    public class PersonViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use latino letters only please")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use Latino letters only please")]
        public string LastName { get; set; }
        
        public Gender Gender { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string PmNumber { get; set; }

        [Required]
        [MinimumAge(18, ErrorMessage = "Minimum Age is 18")]
        public DateTime BirthDate { get; set; }

        public City City { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        public PhoneNumberType PhoneNumberType { get; set; }

        public IFormFile Image { get; set; }
      
    }
}
