using System.Collections.Generic;

namespace HKO.Models.Sektori
{
    public class SektorRadnaSnaga
    {
        public int Godina { get; set; }
        public int Mjesec { get; set; }
        public string Sifra_Sektora { get; set; }
        public string Naziv_Sektora { get; set; }
        public int Broj_U_Sektoru { get; set; }
        public float Postotak_Sektora { get; set; }
        public string Sifra_Podsektora { get; set; }
        public string Naziv_Podsektora { get; set; }
        public string Broj_u_podsektoru { get; set; }
        public float Postotak_Podsektora { get; set; }
    }


}
