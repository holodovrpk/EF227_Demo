using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF227_Demo.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        [MaxLength(33)]
        public string PatientName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        [MaxLength(20)]
        public string? Phone {  get; set; }
        [MaxLength(200)]
        public string? Adress { get; set; }
        public string Polis { get; set;}

        public ICollection<Priem> Priems { get; set; }
    }
}
