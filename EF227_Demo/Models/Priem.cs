using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF227_Demo.Models
{
    public class Priem
    {
        public int PriemId { get; set; }
        public DateOnly Date { get; set; }
        public TimeSpan Time_pr { get; set; }
        public string Result { get; set; }

        public int DoctorId { get; set; }
        
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }

        public int PatientId { get; set; }
        [ForeignKey("PatientId")]

        public Patient Patient { get; set; }
    }
}
