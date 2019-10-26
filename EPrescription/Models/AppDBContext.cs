using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPrescription.Models;

namespace EPrescription.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Pharmacist> Pharmacists { get; set; }
        public DbSet<EPrescription.Models.MedicineType> MedicineType { get; set; }
        public DbSet<EPrescription.Models.MedicineForm> MedicineForm { get; set; }
        public DbSet<EPrescription.Models.Medicine> Medicine { get; set; }
        
    }
}
