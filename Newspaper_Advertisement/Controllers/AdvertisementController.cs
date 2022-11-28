using NewsPaper_Advertisement.DataAccessLayer;
using NewsPaper_Advertisement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Newspaper_Advertisement.Repository;
using Newspaper_Advertisement.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Newspaper_Advertisement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        IAdvertisementRepository _advertisementRepository;

        private readonly NewsPaperAdvertisementContext _db;
        public AdvertisementController(NewsPaperAdvertisementContext db)
        {
            _advertisementRepository = new AdvertisementRepository(db);
            _db = db;
        }

        [HttpGet("get_all_advertisements")]
        public JsonResult GetAllAdvertisements()
        {

            return new JsonResult(_advertisementRepository.GetAllAdvertisements());
        }

        [HttpPost("book_advertisement")]
        public async Task<IActionResult> BookAdvertisements([FromBody] AdvertisementModel book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var Ad_ID = await _advertisementRepository.BookAdvertisements(book);
                    if (Ad_ID > 0)
                    {
                        return Ok(Ad_ID);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpPut("{id:int}")]
        public async Task<JsonResult> UpdateAdvertisements([FromBody] AdvertisementModel ads)
        {

            if (ads == null)
            {
                NotFound();
            }
            return new JsonResult(await _advertisementRepository.UpdateAdvertisements(ads));
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                var data = _db.AdvertisementModels.FirstOrDefault(e => e.Ad_ID == id);
                _db.AdvertisementModels.Remove(data);
                _db.SaveChanges();
                return Ok("Data Deleted Successfully");
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, "ID Not Matched");
            }
        }

        [HttpGet("{id}", Name = "GetAdvById")]
        public IActionResult GetAdvById(int id)
        {
            AdvertisementModel found = _advertisementRepository.GetAdvById(id);
            if (found == null)
            {
                NotFound();
            }
            return (IActionResult)Ok(found);
        }
    }
}
