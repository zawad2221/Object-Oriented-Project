using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescription.Models
{
    public class Prescription
    {
        [Key]
        public int prescriptionId { get; set; }
        [Required]
        public string issueDate { get; set; }
        [Required]
        public int patientId { get; set; }
        [Required]
        public string doctorId { get; set; }
    }
}
