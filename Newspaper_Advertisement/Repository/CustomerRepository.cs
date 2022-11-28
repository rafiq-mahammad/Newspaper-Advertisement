using NewsPaper_Advertisement.DataAccessLayer;
using NewsPaper_Advertisement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPaper_Advertisement.Models
{

    public class CustomerRepository : ICustomerRepository
    {
        private readonly NewsPaperAdvertisementContext _context;

        public CustomerRepository(NewsPaperAdvertisementContext _context)
        {
            this._context = _context;
        }
        public async Task<int> CustomerSignup(CustomerModel cust)
        {
            if (_context != null)
            {
                await _context.CustomerModels.AddAsync(cust);
                await _context.SaveChangesAsync();

                return cust.CID;
            }

            return 0;
        }

        public CustomerModel GetCustomerById(int Id)
        {
            return _context.CustomerModels.ToList().Find(c => c.CID == Id);
        }
    }
}