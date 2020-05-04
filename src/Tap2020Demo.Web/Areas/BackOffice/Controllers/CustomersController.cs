using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tap2020Demo.Web.Areas.BackOffice.Models;
using Uaic.Tap2020Demo.Core;
using Uaic.Tap2020Demo.DataAccess.Repositories;

namespace Tap2020Demo.Web.Areas.BackOffice.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IDataRepository _dataRepository;

        public CustomersController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public IActionResult Index(SearchCustomersViewModel viewModel)
        {
            if (!String.IsNullOrEmpty(viewModel.SearchTerm))
            {
                viewModel.Results = _dataRepository.Query<Customer>()
                    .Where(c => c.FullName.Contains(viewModel.SearchTerm))
                    .ToArray();
            }

            return View(viewModel);
        }

    }
}