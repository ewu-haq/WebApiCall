﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactApiSample.Models;
using ContactApiSample.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContactApiSample.Controllers
{
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        public IContactRepository ContactsRepo { get; set; }

        public ContactController(IContactRepository repo)
        {
            ContactsRepo = repo;
        }

        [HttpGet]
        public IEnumerable<Contacts> GetAll()
        {
            return ContactsRepo.GetAll();
        }

        [HttpGet("id", Name = "GetContacts")]
        public IActionResult GetById(string id)
        {
            var item = ContactsRepo.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost("{id}")]
        public IActionResult Create([FromBody] Contacts item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            ContactsRepo.Add(item);
            return CreatedAtRoute("GetContacts", new {Controller = "Contacts", id= item.MobilePhone} , item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Contacts item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var contactObj = ContactsRepo.Find(id);
            if (contactObj == null)
            {
                return NotFound();
            }
            ContactsRepo.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            ContactsRepo.Remove(id);
        }
    }
}
