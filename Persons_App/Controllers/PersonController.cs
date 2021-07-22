﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persons_App.Models;
using PersonsApp.EntityFrameworkCore.Data.Entities;
using PersonsApp.EntityFrameworkCore.Data.Repositories;
using PersonsApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Persons_App.Controllers
{
    public class PersonController : Controller
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonRepository _repository;
        private readonly IWebHostEnvironment _environment;

        public PersonController(ILogger<PersonController> logger, IPersonRepository repository, IWebHostEnvironment environment)
        {
            _logger = logger;
            _repository = repository;
            _environment = environment;
        }

        public IActionResult Index()
        {
            try
            {
                var result = _repository.GetAllPersons();
                return View(result);

            }
            catch (Exception ex)
            {
                _logger.LogError($"failed to get Persons: {ex} ");
                return BadRequest("Failed to get Persons");

            }
        }
        [HttpGet("person/create")]
        public IActionResult Create()
        {
            ViewBag.Title = "Create Persons";
            return View();
        }

        [HttpPost("person/create")]
        public IActionResult Create(PersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
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
                        Image = model.Image
                    };

                    _repository.CreatePerson(person);
                    _repository.SaveChanges();
                    return RedirectToAction("Index", "Person");

                }
                catch (Exception ex)
                {

                    _logger.LogError($"failed to save a new Person: {ex} ");
                    return BadRequest("Failed to save a new Person");
                }
            }
            else
            {
                throw new InvalidOperationException("Sorry We had Some Problem , plesae try later ");
            }

        }

        //private string UploadedFile(PersonViewModel model)
        //{
        //    string uniqueFileName = null;

        //    if (model.Image != null)
        //    {
        //        string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
        //        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
        //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            model.Image.CopyTo(fileStream);
        //        }
        //    }
        //    return uniqueFileName;
        //}

        [HttpGet("person/edit/id")]
        public IActionResult Edit(int Id)
        {
            ViewBag.Title = "Edit Persons";
            if (Id != 0)
            {
                var person = _repository.GetPersonById(Id);
                return View(person);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Edit(EditPersonViewModel model)
        {
            if (ModelState.IsValid)
            { 
                try
                {
                    var person = (Person)_repository.GetPersonById(model.Id);
                    person.FirstName = model.FirstName;
                    person.LastName = model.LastName;
                    person.Gender = model.Gender;
                    person.City = model.City;
                    person.BirthDate = model.BirthDate;
                    person.PhoneNumber = model.PhoneNumber;
                    person.PhoneNumberType = model.PhoneNumberType;
                    person.PmNumber = model.PmNumber;
                   
                    _repository.UpdatePerson(person);
                    _repository.SaveChanges();
                    return RedirectToAction("index");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"failed to save a Updated Person: {ex} ");
                    return BadRequest("Failed to save a Updated Person");
                }
               
            }
            return BadRequest("Failed to save a Updated Person");
        }


        [HttpGet("person/detail/id")]
        public IActionResult Detail(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (id != 0)
                    {
                         var detailperson =_repository.GetPersonById(id);
                        return View(detailperson);
                    }
                    else
                    {
                        return BadRequest("Not Found Peron Details ");
                    }
                      
                }
                catch (Exception ex )
                {

                    _logger.LogError($"Failed to Move Detail Page: {ex} ");
                    return BadRequest("Failed to Move Detail Page ");
                }
            }
            else
            {
                throw new InvalidOperationException("Sorry We had Some Problem , plesae try later ");
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (id != 0)
                    {
                        _repository.DeletePerson(id);
                        _repository.SaveChanges();
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
            else
            {
                throw new InvalidOperationException("Sorry We had Some Problem , plesae try later ");
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
