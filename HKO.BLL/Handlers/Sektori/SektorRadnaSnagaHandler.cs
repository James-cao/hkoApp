
using System.Collections.Generic;
using HKO.Models.DTOs.Sektori;
using HKO.Models.Sektori;

namespace HKO.BLL.Handlers.Sektori
{
    public static class SektorRadnaSnagaHandler
    {
        public static List<SektorRadnaSnagaDTO> MapSektorRadnaSnagaToDto(IEnumerable<SektorRadnaSnaga> items)
        {
            List<SektorRadnaSnagaDTO> response = new List<SektorRadnaSnagaDTO>();

            foreach (var item in items)
            {
                if (!string.IsNullOrEmpty(item.Sifra_Sektora))
                {
                    SektorRadnaSnagaDTO dto = new SektorRadnaSnagaDTO();
                    dto.Sektor = new string[2];
                    dto.Sektor[0] = item.Naziv_Sektora;
                    dto.Sektor[1] = item.Naziv_Podsektora;

                    if (!string.IsNullOrEmpty(item.Sifra_Podsektora))
                    {
                        SektorRadnaSnagaDTO1 vrijednost = new SektorRadnaSnagaDTO1();
                        vrijednost.Broj_U_Podsektoru = item.Broj_u_podsektoru;
                        vrijednost.Postotak_Podsektora = item.Postotak_Podsektora;
                        vrijednost.Sifra_Sektora = item.Sifra_Sektora;
                        vrijednost.Sifra_Podsektora = item.Sifra_Podsektora;

                        dto.Vrijednost = vrijednost;
                    }
                    else
                    {
                        SektorRadnaSnagaDTO1 vrijednost = new SektorRadnaSnagaDTO1();
                        vrijednost.Broj_U_Podsektoru = item.Broj_u_podsektoru;
                        vrijednost.Postotak_Podsektora = item.Postotak_Podsektora;
                        vrijednost.Sifra_Sektora = item.Sifra_Sektora;

                        dto.Vrijednost = vrijednost;
                    }

                    response.Add(dto);
                }
            }

            return response;
        }

    }
}
