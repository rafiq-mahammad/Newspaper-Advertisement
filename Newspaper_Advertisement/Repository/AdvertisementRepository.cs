using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newspaper_Advertisement.Models;
using NewsPaper_Advertisement.DataAccessLayer;

namespace Newspaper_Advertisement.Repository
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private readonly NewsPaperAdvertisementContext _context;
        public AdvertisementRepository(NewsPaperAdvertisementContext _context)
        {
            this._context = _context;
        }
        public IEnumerable<AdvertisementModel> GetAllAdvertisements()
        {
            return _context.AdvertisementModels.ToList();
        }
        public async Task<int> BookAdvertisements(AdvertisementModel book)
        {
            if (_context != null)
            {
                await _context.AdvertisementModels.AddAsync(book);
                _context.SaveChanges();
                return book.Ad_ID;
            }
            return 0;
        }
        public async Task<bool> UpdateAdvertisements(AdvertisementModel ads)
        {
            if (ads == null)
            {
                throw new ArgumentNullException("ads");
            }
            var index = _context.AdvertisementModels.Find(ads.Ad_ID);
            if (index == null)
            {
                return false;
            }
            _context.AdvertisementModels.Remove(index);
            await _context.AdvertisementModels.AddAsync(ads);
            await _context.SaveChangesAsync();
            return true;
        }
        public AdvertisementModel GetAdvById(int Id)
        {
            return _context.AdvertisementModels.ToList().Find(c => c.Ad_ID == Id);
        }
    }
}
