using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uaic.Tap2020Demo.DataAccess.Repositories;

namespace Uaic.Tap2020Demo.Core.Services
{
    public interface ICustomersService
    {
        Task<IEnumerable<Customer>> SearchCustomersAsync(string searchTerm);
    }

    public class CustomersService : ICustomersService
    {
        private readonly IDataRepository _dataRepository;

        public CustomersService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public  Task<IEnumerable<Customer>> SearchCustomersAsync(string searchTerm)
        {
            if (String.IsNullOrEmpty(searchTerm))
            {
                return Task.FromResult(Enumerable.Empty<Customer>());
            }

            var results = _dataRepository.Query<Customer>()
                .Where(c => c.FullName.Contains(searchTerm))
                .ToArray() as IEnumerable<Customer>;

            return Task.FromResult(results);
        }
    }
}
