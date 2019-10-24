using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescription.Models
{
    public class Pharmacist
    {
        [Key]
        public string pharmacistId { get; set; }
        [Required]
        public string storeName { get; set; }
        [Required]
        public string drugeLicence { get; set; }
        [Required]
        public string pharmacistPhoneNumber { get; set; }
        [Required]
        public string storeAddress { get; set; }
        [Required]
        public string pharmacistPassword { get; set; }

    }
}
