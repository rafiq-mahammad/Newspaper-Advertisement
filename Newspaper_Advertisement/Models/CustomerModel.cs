using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewsPaper_Advertisement.Models
{
    public class CustomerModel
    {
        [Key]
        public int CID { get; set; }
        public string firstName { get; set; }      
        public string lastName { get; set; }  
        
        [Required]
        public string username { get; set; }

        public string emailId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}