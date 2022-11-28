using Newspaper_Advertisement.Models;
using NewsPaper_Advertisement.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newspaper_Advertisement.Repository
{
    public class FeedbackRepository :IFeedbackRepository
    {
        private readonly NewsPaperAdvertisementContext _context;
        public FeedbackRepository(NewsPaperAdvertisementContext _context)
        {
            this._context = _context;
        }
        public IEnumerable<Feedback> GetAllFeedbacks()
        {
            return _context.Feedbacks.ToList();
        }
        public async Task<int> PostFeedbacks(Feedback book)
        {
            if (_context != null)
            {
                await _context.Feedbacks.AddAsync(book);
                _context.SaveChanges();
                return book.Id;
            }
            return 0;
        }
    }
}
