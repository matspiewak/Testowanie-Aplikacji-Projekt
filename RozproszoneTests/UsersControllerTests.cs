using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using Rozproszone.Controllers;
using Rozproszone.Models;
using Rozproszone.Utilities;
using System;
using System.Data.Entity;
using System.Linq;

namespace RozproszoneTests
{
    [TestFixture]
    class UsersControllerTests
    {

        DbContextOptions<UserContext> options;
        public DbContextOptions<UserContext> setUp()
        {
            options = new DbContextOptionsBuilder<UserContext>()
                .UseInMemoryDatabase(databaseName: "Books")
                .Options;

            using (var context = new UserContext(options))
            {
                if (context.Users.Count() == 0)
                {
                    context.Users.Add(new User { Id = 1, Username = "test", Password = "test" });
                    context.SaveChanges();
                }
            }

            return options;
        }

        [Test]
        public void UsersController_WhenCalled_AddsUser()
        {
            setUp();
            using (var context = new UserContext(options))
            {
                var UsersController = new UsersController(context);
                var result = UsersController.SignUpUser(new User { Id=2,Username="test", Password="test"}).Result;
                Assert.IsInstanceOf<OkResult>(result);
            }
        }
    }
}
