using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKO.Models.DTOs.Sektori
{
    public class ZaposlenostUdjelDTO
    {
        public string RodID { get; set; }
        public string RodNaziv { get; set; }
        public double Sektor { get; set; }
        public double Ukupno { get; set; }
    }
}
