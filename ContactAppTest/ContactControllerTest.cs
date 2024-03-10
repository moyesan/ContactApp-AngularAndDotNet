using System;
using Xunit;

using ContactAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Extensions.Configuration;
using ContactAPI.Contracts;
using ContactAPI.Controllers;
using ContactAPI.Repository;

namespace ContactAppTest
{
  
    public class ContactControllerTest
    {
        ContactController _controller;
        IContactRepository _contactRepo;
        ILoggerManager _logger;

        public ContactControllerTest()
        {
            //_contactRepo = new ContactRepository();
            _controller = new ContactController(_contactRepo, _logger);
        }

        [Fact]
        public void GetContacts()
        {
            // Arrange
            //Act
            var result = _controller.GetContacts();


            //Assert
            Assert.IsType<OkObjectResult>(result.Result);

            var list = result.Result as OkObjectResult;

            Assert.IsType<List<Contact>>(list.Value);



            var lstContact = list.Value as List<Contact>;
            Assert.Equal(5, lstContact.Count);


        }
    }
}
