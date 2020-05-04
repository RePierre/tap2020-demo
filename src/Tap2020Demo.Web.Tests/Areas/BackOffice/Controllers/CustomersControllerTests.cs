using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tap2020Demo.Web.Areas.BackOffice.Controllers;
using Tap2020Demo.Web.Areas.BackOffice.Models;
using Uaic.Tap2020Demo.Core;
using Uaic.Tap2020Demo.DataAccess.Repositories;

namespace Tap2020Demo.Web.Tests.Areas.BackOffice.Controllers
{
    public class CustomersControllerTests
    {
        public Mock<IDataRepository> DataRepository { get; private set; }

        public CustomersController Controller { get; private set; }

        protected void Initialize()
        {
            DataRepository = new Mock<IDataRepository>();
            Controller = new CustomersController(DataRepository.Object);
        }

        [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
        public class WhenSearchStringIsEmpty : CustomersControllerTests
        {
            [TestInitialize]
            public void TestInitialize()
            {
                Initialize();
            }

            [TestMethod]
            public void ViewModelResultsShouldBeEmpty()
            {
                var actionResult = Controller.Index(new SearchCustomersViewModel { SearchTerm = String.Empty });
                var viewModel = (actionResult as ViewResult).Model as SearchCustomersViewModel;

                Assert.IsFalse(viewModel.Results.Any());
                DataRepository.Verify(_ => _.Query<Customer>(), Times.Never());
            }
        }

        [TestClass]
        public class WhenSearchStringIsNotEmpty : CustomersControllerTests
        {
            public string SearchTerm { get; private set; }

            [TestInitialize]
            public void TestInitialize()
            {
                Initialize();
                SearchTerm = Guid.NewGuid().ToString();
                DataRepository.Setup(_ => _.Query<Customer>())
                    .Returns(new Customer[]
                    {
                        new Customer
                        {
                            Id = Guid.NewGuid(),
                            FullName = SearchTerm
                        }
                    }.AsQueryable());
            }

            [TestMethod]
            public void ControllerShouldPopulateResults()
            {
                var actionResult = Controller.Index(new SearchCustomersViewModel { SearchTerm = SearchTerm });
                var viewModel = (actionResult as ViewResult).Model as SearchCustomersViewModel;

                Assert.AreEqual(1, viewModel.Results.Count());
            }
        }
    }
}
