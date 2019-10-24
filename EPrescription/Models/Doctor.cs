using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescription.Models
{
    public class Doctor
    {
        [Key]
        public string doctorId { get; set; }
        [Required]
        public string doctorName { get; set; }
        [Required]
        public string doctorPhoneNumber { get; set; }
        [Required]
        public string doctorDesignation { get; set; }
        [Required]
        public string doctorSpecializedArea { get; set; }
        [Required]
        public string doctorPassword { get; set; }


    }
}
