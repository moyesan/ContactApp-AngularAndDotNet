using ContactAPI.Contracts;
using ContactAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
		private readonly IContactRepository _contactRepo;

		public ContactController(IContactRepository contactRepo)
		{
			_contactRepo = contactRepo;
		}


		// GET: Contact/GetContactList
		[HttpGet("GetContactList")]
		public async Task<IActionResult> GetContacts()
		{
			try
			{
				var contacts = await _contactRepo.GetContacts();
				return Ok(contacts);
			}
			catch (Exception ex)
			{
				//log error
				return StatusCode(500, ex.Message);
			}
		}


		// GET: Contact/GetContactById/5
		[HttpGet("GetContactById/{contactId}", Name = "GetContactById")]
		public async Task<IActionResult> GetContact(int contactId)
		{
			try
			{
				var contact = await _contactRepo.GetContact(contactId);
				if (contact == null)
					return NotFound();
				return Ok(contact);
			}
			catch (Exception ex)
			{
				//log error
				return StatusCode(500, ex.Message);
			}
		}


		// POST: Contact/AddContact
		[HttpPost("AddContact")]
		public async Task<IActionResult> AddContact(ContactDTO contact)
		{
			try
			{
				var createdContact = await _contactRepo.CreateContact(contact);
				return CreatedAtRoute("ContactById", new { contactId = createdContact.ContactId }, createdContact);
			}
			catch (Exception ex)
			{
				//log error
				return StatusCode(500, ex.Message);
			}
		}


		// PUT: Contact/UpdateContact/5
		[HttpPut("UpdateContact/{contactId}")]
		public async Task<IActionResult> UpdateContact(int contactId, ContactUpadteDTO contact)
		{
			try
			{
				var dbContact = await _contactRepo.GetContact(contactId);
				if (dbContact == null)
					return NotFound();

				await _contactRepo.UpdateContact(contactId, contact);
				return NoContent();
			}
			catch (Exception ex)
			{
				//log error
				return StatusCode(500, ex.Message);
			}
		}


		// POST: Contact/DeleteContact/5
		[HttpDelete("DeleteContact/{contactId}")]
		public async Task<IActionResult> DeleteContact(int contactId)
		{
			try
			{
				var dbContact = await _contactRepo.GetContact(contactId);
				if (dbContact == null)
					return NotFound();

				await _contactRepo.DeleteContact(contactId);
				return NoContent();
			}
			catch (Exception ex)
			{
				//log error
				return StatusCode(500, ex.Message);
			}
		}
	}
}
