using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newspaper_Advertisement.Models;
using Newspaper_Advertisement.Repository;
using NewsPaper_Advertisement.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newspaper_Advertisement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        IFeedbackRepository _feedbackRepository;

        private readonly NewsPaperAdvertisementContext _db;
        public FeedbackController(NewsPaperAdvertisementContext db)
        {
            _feedbackRepository = new FeedbackRepository(db);
            _db = db;
        }

        [HttpGet("GetAllFeedbacks")]
        public JsonResult GetAllFeedbacks()
        {

            return new JsonResult(_feedbackRepository.GetAllFeedbacks());
        }

        [HttpPost("Post_Feedback")]
        public async Task<IActionResult> PostFeedbacks([FromBody] Feedback book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var Id = await _feedbackRepository.PostFeedbacks(book);
                    if (Id> 0)
                    {
                        return Ok(Id);
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
    }
}
