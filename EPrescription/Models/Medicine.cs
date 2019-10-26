using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescription.Models
{
    public class Medicine
    {
        [Key]
        public string medicineId { get; set; }
        [Required]
        public string medicineName { get; set; }
        
        public string medicineSingleUniteQuantity { get; set; }

        [Required]
        [Display(Name ="Medicine Form")] 
        public string medicineFormId { get; set; }
        public MedicineForm MedicineForm { get; set; }

        [Required]
        [Display(Name = "Medicine Type")]
        public string medicineTypeId { get; set; }
        public MedicineType MedicineType { get; set; }

        [Required]
        [Display(Name = "Medicine Company")]
        public string companyId { get; set; }
        public Company Company { get; set; }

    }
}
