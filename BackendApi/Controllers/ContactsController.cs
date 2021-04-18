using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Utilities.Contacts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Utilities.Contacts;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var contact = await _contactService.GetList();
            return Ok(contact);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int idContact)
        {
            var contact = await _contactService.GetById(idContact);
            if (contact == null)
                return BadRequest("Cannot find contact");
            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]ContactCreate request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var idContact = await _contactService.Create(request);
            if (idContact == 0)
                return BadRequest();

            var contact = await _contactService.GetById(idContact);

            return CreatedAtAction(nameof(idContact), new { id = idContact }, contact);
        }
    }
}