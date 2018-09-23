using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Innovinity.Models
{
    public class Clinics
    {
        
        [Key]
        public int ClinicsID { get; set; }
        public string Name { get; set; }
        public string Arabic_Name { get; set; }
    }
}
