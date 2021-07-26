using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persons_App.Application.Interfaces;
using Persons_App.Application.ViewModels;
using Persons_App.Domain.Entities;
using Persons_App.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Persons_App.Controllers
{
    public class PersonController : Controller
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;
        private readonly IWebHostEnvironment _environment;

        public PersonController(ILogger<PersonController> logger, IPersonService personService, IWebHostEnvironment environment)
        {
            _logger = logger;
            _personService = personService;
            _environment = environment;
        }

        public IActionResult Index()
        {
            try
            {
                var result = _personService.GetPersons();
                var vm = new PersonIndexViewModel
                {
                    Persons = result,
                    SearchTerm = ""
                };

                return View(vm);

            }
            catch (Exception ex)
            {
                _logger.LogError($"failed to get Persons: {ex} ");
                return BadRequest("Failed to get Persons");

            }
        }

        [HttpGet]
        public IActionResult Search(string searchTerm)
        {
            var result = _personService.SearchPerson(searchTerm);
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var vm = new PersonIndexViewModel
                {
                    Persons = result,
                    SearchTerm = searchTerm
                };
                return View("index", vm);
            }
            var res = _personService.GetPersons();
            return View("index",res);

        }






        [HttpGet("person/create")]
        public IActionResult Create()
        {
            ViewBag.Title = "Create Persons";
            return View();
        }

        [HttpPost("person/create")]
        public IActionResult Create(CreatePersonsViewModel model)
        {
            
                try
                {
                    string uniqueFileName = null;
                    if (model.Image != null)
                    {
                      string uploadsFolder = Path.Combine(_environment.WebRootPath, "Images");
                      uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                      string FilePath = Path.Combine(uploadsFolder, uniqueFileName);
                        model.Image.CopyTo(new FileStream(FilePath, FileMode.Create));
                    }

                    var person = new Person()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Gender = model.Gender,
                        City = model.City,
                        BirthDate = model.BirthDate,
                        PhoneNumber = model.PhoneNumber,
                        PhoneNumberType = model.PhoneNumberType,
                        PmNumber = model.PmNumber,
                        Image = uniqueFileName
                    };

                    _personService.CreatePerson(person);
                    _personService.SaveChanges();
                    return RedirectToAction("Index", "Person");

                }
                catch (Exception ex)
                {

                    _logger.LogError($"failed to save a new Person: {ex} ");
                    return BadRequest("Failed to save a new Person");
                }
            

        }

        [HttpGet("person/edit/{id}")]
        public IActionResult Edit(int Id)
        {
            ViewBag.Title = "Edit Persons";
            if (Id != 0)
            {

                var person = _personService.GetPersonById(Id);
                var vm = new EditPersonViewModel
                {
                    BirthDate = person.BirthDate,
                    City = (City)person.City,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Gender = (Gender)person.Gender,
                    PhoneNumber = person.PhoneNumber,
                    PhoneNumberType = person.PhoneNumberType,
                    PmNumber = person.PmNumber,
                    Image = person.Image
                };
                return View(vm);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Edit(EditPersonViewModel model)
        {

                try
                {
                    string uniqueFileName = null;
                    if (model.ImagePath != null)
                    {
                        string uploadsFolder = Path.Combine(_environment.WebRootPath, "Images");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImagePath.FileName;
                        string FilePath = Path.Combine(uploadsFolder, uniqueFileName);
                        model.ImagePath.CopyTo(new FileStream(FilePath, FileMode.Create));
                    }
               
                        

                    var person =_personService.GetPersonById(model.Id);
                        person.Id = model.Id;
                        person.FirstName = model.FirstName;
                        person.LastName = model.LastName;
                        person.Gender = model.Gender;
                        person.City = model.City;
                        person.BirthDate = model.BirthDate;
                        person.PhoneNumber = model.PhoneNumber;
                        person.PhoneNumberType = model.PhoneNumberType;
                        person.PmNumber = model.PmNumber;
                if (uniqueFileName != null)
                {
                    person.Image = model.Image = uniqueFileName;
                }
                else { model.Image = person.Image; }
                

                _personService.UpdatePerson(person);
                        _personService.SaveChanges();
                        return RedirectToAction("index");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"failed to save a Updated Person: {ex} ");
                    return BadRequest("Failed to save a Updated Person");
                }
               

        }


        [HttpGet("person/detail/{id}")]
        public IActionResult Detail(int Id)
        {

                try
                {
                    if (Id != 0)
                    {
                        var person = _personService.GetPersonById(Id);
                        var vm = new DetailPersonViewModel
                        {
                            Id = person.Id,
                            BirthDate = person.BirthDate,
                            City = (City)person.City,
                            FirstName = person.FirstName,
                            LastName = person.LastName,
                            Gender = (Gender)person.Gender,
                            PhoneNumber = person.PhoneNumber,
                            PhoneNumberType = person.PhoneNumberType,
                            PmNumber = person.PmNumber,
                            Image = person.Image
                            
                        };
                        return View(vm);
                    }
                    else
                    {
                        return NotFound();
                    }

                }
                catch (Exception ex )
                {

                    _logger.LogError($"Failed to Move Detail Page: {ex} ");
                    return BadRequest("Failed to Move Detail Page ");
                }

        }

        public IActionResult Delete(int id)
        {

                try
                {
                    if (id != 0)
                    {
                        _personService.DeletePerson(id);
                        _personService.SaveChanges();
                        return RedirectToAction("index", "Person");
                    }
                    else
                    {
                        return BadRequest("Failed to Delete  Person");
                    }
                }
                catch (Exception ex)
                {

                    _logger.LogError($"failed to Delete  Person: {ex} ");
                    return BadRequest("Failed to Delete  Person");
                }
        

        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
