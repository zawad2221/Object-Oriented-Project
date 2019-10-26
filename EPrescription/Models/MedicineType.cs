using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescription.Models
{
    public class MedicineType
    {
        [Key]
        public string medicineTypeId { get; set; }
        [Required]
        public string medicineTypeName { get; set; }
    }
}
