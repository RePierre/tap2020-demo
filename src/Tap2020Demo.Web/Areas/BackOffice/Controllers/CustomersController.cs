using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tap2020Demo.Web.Areas.BackOffice.Models;
using Uaic.Tap2020Demo.Core;
using Uaic.Tap2020Demo.Core.Services;
using Uaic.Tap2020Demo.DataAccess.Repositories;

namespace Tap2020Demo.Web.Areas.BackOffice.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomersService _customersService;

        public CustomersController(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        [Authorize]
        public async Task<IActionResult> IndexAsync(SearchCustomersViewModel viewModel)
        {
            var results = await _customersService.SearchCustomersAsync(viewModel.SearchTerm);

            return View(new SearchCustomersViewModel
            {
                SearchTerm = viewModel.SearchTerm,
                Results = results
            });
        }

    }
}