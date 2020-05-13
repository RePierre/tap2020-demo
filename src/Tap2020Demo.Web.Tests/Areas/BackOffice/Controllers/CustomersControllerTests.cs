using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tap2020Demo.Web.Areas.BackOffice.Controllers;
using Tap2020Demo.Web.Areas.BackOffice.Models;
using Uaic.Tap2020Demo.Core;
using Uaic.Tap2020Demo.Core.Services;
using Uaic.Tap2020Demo.DataAccess.Repositories;

namespace Tap2020Demo.Web.Tests.Areas.BackOffice.Controllers
{
    public class CustomersControllerTests
    {
        public Mock<ICustomersService> CustomersService { get; private set; }

        public CustomersController Controller { get; private set; }

        protected void Initialize()
        {
            CustomersService = new Mock<ICustomersService>();
            Controller = new CustomersController(CustomersService.Object);
        }

        [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
        public class WhenCallindIndex : CustomersControllerTests
        {
            public string SearchTerm { get; private set; }
            public IEnumerable<Customer> Customers { get; private set; }

            [TestInitialize]
            public void TestInitialize()
            {
                Initialize();
                SearchTerm = Guid.NewGuid().ToString();
                Customers = Enumerable.Range(1, 5)
                    .Select(_ => new Customer
                    {
                        Id = Guid.NewGuid()
                    })
                    .ToArray();

                CustomersService.Setup(_ => _.SearchCustomersAsync(It.IsAny<string>()))
                    .Returns(Task.FromResult(Customers));
            }

            [TestMethod]
            public void ShouldCallCustomerService()
            {
                var actionResult = Controller.IndexAsync(new SearchCustomersViewModel { SearchTerm = SearchTerm });

                CustomersService.Verify(_ => _.SearchCustomersAsync(It.Is<String>(s => s == SearchTerm)), Times.Once());
            }

            [TestMethod]
            public void ShouldPopulateViewModelResults()
            {
                var actionResult = Controller.IndexAsync(new SearchCustomersViewModel { SearchTerm = SearchTerm });
                var viewModel = (actionResult.Result as ViewResult).Model as SearchCustomersViewModel;

                Assert.IsTrue(Customers.SequenceEqual(viewModel.Results));
            }
        }
    }
}
