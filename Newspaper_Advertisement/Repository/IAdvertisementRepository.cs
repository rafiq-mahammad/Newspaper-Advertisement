using Newspaper_Advertisement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newspaper_Advertisement.Repository
{
    interface IAdvertisementRepository
    {
        IEnumerable<AdvertisementModel> GetAllAdvertisements();
        Task<int> BookAdvertisements(AdvertisementModel book);
        Task<bool> UpdateAdvertisements(AdvertisementModel ads);
        //Task<bool> DeleteAdvertisement(int book);
        AdvertisementModel GetAdvById(int id);
    }
}
