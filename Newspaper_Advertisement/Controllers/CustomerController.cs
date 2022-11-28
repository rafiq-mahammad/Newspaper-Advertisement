using NewsPaper_Advertisement.DataAccessLayer;
using NewsPaper_Advertisement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace NewsPaper_Advertisement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerRepository _CRepo;
        //public CustomerController(NewsPaperAdvertisementContext context)
        //{
        //    _CRepo = new CustomerRepository(context);
        //}

        private readonly NewsPaperAdvertisementContext _db;
        public CustomerController(NewsPaperAdvertisementContext db)
        {
            _CRepo = new CustomerRepository(db);
            _db = db;
        }

        //[HttpPost("Signup")]
        //public async Task<IActionResult> CustomerSignup([FromBody] CustomerModel ncust)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var CID = await _CRepo.CustomerSignup(ncust);
        //            if (CID > 0)
        //            {
        //                return Ok(CID);
        //            }
        //            else
        //            {
        //                return NotFound();
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            return BadRequest();
        //        }
        //    }
        //    return BadRequest();
        //}

        [HttpPost("Signup")]
        public async Task<IActionResult> CustomerSignup([FromBody] CustomerModel ncust)
        {
            if (ncust == null)
                return BadRequest();
            if (await CheckUserNameExistAsync(ncust.username))
                return BadRequest(new { Message = "Username Already Exist!!!"});
            if (await CheckEmailExistAsync(ncust.emailId))
                return BadRequest(new { Message = "Email Already Exist!!!" });


            await _db.CustomerModels.AddAsync(ncust);
            await _db.SaveChangesAsync();
            return Ok(new
            { Message = "User Registered" });
        }
        private Task<bool> CheckUserNameExistAsync(string username)
            => _db.CustomerModels.AnyAsync(x => x.username == username);
        private Task<bool> CheckEmailExistAsync(string email)
           => _db.CustomerModels.AnyAsync(x => x.emailId == email);

        //[HttpPost("login")]
        //public IActionResult CustomerLogin([FromBody] CustomerModel ncust)
        //{
        //    if (ncust == null)
        //    {
        //        return BadRequest();
        //    }
        //    else
        //    {
        //        return Ok(new
        //        {
        //            Message = "Logged in Successfully",
        //        });
        //    }
        //}
        [HttpPost]
        [Route("login")]
        public IActionResult Login(CustomerModel user)
        {
            var data = _db.CustomerModels.FirstOrDefault(x => x.username == user.username && x.password == user.password);

            if (data != null)
            {

                return StatusCode(StatusCodes.Status200OK, "Login Successfull");

            }

            return StatusCode(StatusCodes.Status400BadRequest, "Login Failed");
        }
        [HttpGet("{id}", Name = "GetCustomerById")]

        public IActionResult GetCustomerById(int id)

        {

            CustomerModel found = _CRepo.GetCustomerById(id);

            if (found == null)
            {
                NotFound();
            }

            return (IActionResult)Ok(found);

        }
    }

}