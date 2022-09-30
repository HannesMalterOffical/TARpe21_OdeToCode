using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdeToCode.Controllers;
using OdeToCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToCode.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {

        private static ILogger<HomeController> _logger;

        public HomeControllerTests()
        {
            var serviceprovider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();
            var factory = serviceprovider.GetService<ILoggerFactory>();
            _logger = factory.CreateLogger<HomeController>();
        }

        [TestMethod()]
        public void AboutTest()
        {
            // Arrange
            HomeController controller = new HomeController(_logger);
            // Act
            ViewResult result = controller.About() as ViewResult;
            // Assert
            Assert.IsNotNull(result.Model);
            AboutModel aboutModel = result.Model as AboutModel;
            Assert.AreEqual("Hannes", aboutModel.Name);
        }
    }
}