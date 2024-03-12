using ContactAPI.Context;
using ContactAPI.Contracts;
using ContactAPI.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAPI.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly DapperContext _context;
        public ContactRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            var query = "SELECT * FROM tblContact ORDER BY ContactId";
            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<Contact>(query);
                return companies.ToList();
            }
        }

        public async Task<Contact> GetContact(int contactId)
        {
            var query = "SELECT * FROM tblContact WHERE ContactId = @ContactId";
            using (var connection = _context.CreateConnection())
            {
                var contact = await connection.QuerySingleOrDefaultAsync<Contact>(query, new { contactId });
                return contact;
            }
        }

        public async Task<Contact> CreateContact(ContactDTO contact)
        {
            var query = "INSERT INTO tblContact (ContactId, FirstName, LastName, Email, PhoneNumber, Address)" +
                " VALUES (@ContactId, @FirstName, @LastName, @Email, @PhoneNumber, @Address)" +
                " SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("ContactId", contact.ContactId, DbType.Int32);
            parameters.Add("FirstName", contact.FirstName, DbType.String);
            parameters.Add("LastName", contact.LastName, DbType.String);
            parameters.Add("Email", contact.Email, DbType.String);
            parameters.Add("PhoneNumber", contact.PhoneNumber, DbType.String);
            parameters.Add("Address", contact.LastName, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.ExecuteAsync(query, parameters);

                var createdContact = new Contact
                {
                    ContactId = contact.ContactId,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Email = contact.Email,
                    PhoneNumber = contact.PhoneNumber,
                    Address = contact.Address
                };
                return createdContact;
            }
        }

        public async Task UpdateContact(int contactId, ContactUpadteDTO Contact)
        {
            var query = "UPDATE tblContact SET FirstName = @FirstName, LastName = @LastName, Email = @Email, PhoneNumber = @PhoneNumber, Address = @Address" +
                " WHERE ContactId = @ContactId";

            var parameters = new DynamicParameters();
            parameters.Add("ContactId", contactId, DbType.Int32);
            parameters.Add("FirstName", Contact.FirstName, DbType.String);
            parameters.Add("LastName", Contact.LastName, DbType.String);
            parameters.Add("Email", Contact.Email, DbType.String);
            parameters.Add("PhoneNumber", Contact.PhoneNumber, DbType.String);
            parameters.Add("Address", Contact.Address, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteContact(int contactId)
        {
            var query = "DELETE FROM tblContact WHERE ContactId = @ContactId";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { contactId });
            }
        }

    }
}
