using System.Collections.Generic;

namespace HKO.Models.DTOs.Lookups
{
    public class HkoSifreDTO
    {

        public string ID { get; set; }
        public string Naziv { get; set; }
        public IList<HkoSifreDTO> Podsektori { get; set; }
    }
}
