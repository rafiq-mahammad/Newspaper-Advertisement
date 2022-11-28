using Newspaper_Advertisement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newspaper_Advertisement.Repository
{
    interface IFeedbackRepository
    {
        IEnumerable<Feedback> GetAllFeedbacks();
        Task<int> PostFeedbacks(Feedback book);
    }
}
