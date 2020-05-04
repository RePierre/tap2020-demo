using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uaic.Tap2020Demo.Core;

namespace Tap2020Demo.Web.Areas.BackOffice.Models
{
    public class SearchCustomersViewModel
    {
        public SearchCustomersViewModel()
        {
            Results = Enumerable.Empty<Customer>();
        }

        public string SearchTerm { get; set; }

        public IEnumerable<Customer> Results { get; internal set; }
    }
}
