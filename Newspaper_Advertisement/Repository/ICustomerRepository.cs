using NewsPaper_Advertisement.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NewsPaper_Advertisement.Models
{
    interface ICustomerRepository
    {
        Task<int> CustomerSignup(CustomerModel cust);
       // bool CustomerLogin(CustomerModel cust);
        CustomerModel GetCustomerById(int id);
    }
}