using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescription.Models
{
    public class Company
    {
        [Key]
        public string companyId { get; set; }
        [Required]
        public string companyName { get; set; }
        [Required]
        public string companyLicence { get; set; }
        [Required]
        public string companyEmail { get; set; }
        [Required]
        public string companyAddress { get; set; }
        [Required]
        public string companyPassword { get; set; }
    }
}
