using NewsPaper_Advertisement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Newspaper_Advertisement.Models
{
    public class AdvertisementModel
    {
        [Key]
        public int Ad_ID { get; set; }

        public String UserName { get; set; }
        public String Ad_Title { get; set; }
        public String Ad_Description { get; set; }
        public String PageNumber { get; set; }
        public String Category { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfPost { get; set; }
    }
}
