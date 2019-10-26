using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescription.Models
{
    public class MedicineForm
    {
        [Key]
        public string medicineFormId { get; set; }
        [Required]
        public string medicineFormName { get; set; }
    }
}
