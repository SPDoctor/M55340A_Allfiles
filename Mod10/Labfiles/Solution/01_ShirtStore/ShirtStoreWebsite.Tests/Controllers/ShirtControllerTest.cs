using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ShirtStoreWebsite.Controllers;
using ShirtStoreWebsite.Models;
using ShirtStoreWebsite.Services;
using ShirtStoreWebsite.Tests.FakeRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShirtStoreWebsite.Tests.Controllers
{
    [TestClass]
    public class ShirtControllerTest
    {
        [TestMethod]
        public void IndexModelShouldContainAllShirts()
        {
            IShirtRepository fakeShirtRepository = new FakeShirtRepository();
            Mock<ILogger<ShirtController>> mockLogger = new Mock<ILogger<ShirtController>>();
            ShirtController shirtController = new ShirtController(fakeShirtRepository, mockLogger.Object);
            ViewResult? viewResult = shirtController.Index() as ViewResult;
            Assert.IsNotNull(viewResult);
            Assert.IsNotNull(viewResult.Model);
            List<Shirt> shirts = (List<Shirt>)viewResult.Model;
            Assert.HasCount(3, shirts);
        }
    }
}
