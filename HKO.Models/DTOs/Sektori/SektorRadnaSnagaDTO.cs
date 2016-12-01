namespace HKO.Models.DTOs.Sektori
{
    public class SektorRadnaSnagaDTO
    {
        public string[] Sektor { get; set; }
        public SektorRadnaSnagaDTO1 Vrijednost { get; set; }
    }

    public class SektorRadnaSnagaDTO1
    {
        public string Broj_U_Podsektoru { get; set; }
        public float Postotak_Podsektora { get; set; }
        public string Sifra_Sektora { get; set; }
        public string Sifra_Podsektora { get; set; }
    }
}
