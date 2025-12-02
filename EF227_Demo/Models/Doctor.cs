using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF227_Demo.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        [Required, MaxLength(33)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Spec { get; set; }
        [MaxLength(20)]
        public string? Phone { get; set; }
        public string Category { get; set; }

        public ICollection<Priem> Priems { get; set; }
    }
}
