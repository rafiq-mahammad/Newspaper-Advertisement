using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Newspaper_Advertisement.Models
{
    public class AdminModel
    {
        [Key]
        public string adminId { get; set; }
        public string password { get; set; }
    }
}
