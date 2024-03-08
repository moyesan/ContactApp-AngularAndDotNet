using ContactAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAPI.Contracts
{
    public interface IContactRepository
    {
        public Task<IEnumerable<Contact>> GetContacts();

        public Task<Contact> GetContact(int contactId);

        public Task<Contact> CreateContact(ContactDTO contact);

        public Task UpdateContact(int contactId, ContactUpadteDTO company);

        public Task DeleteContact(int contactId);
    }
}
