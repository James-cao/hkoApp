using System;
using HKO.Models.DTOs.Sektori;

namespace HKO.BLL.Mocks.Sektori
{
    public static class SektorskaZanimanjaDjelatnostiMocking
    {

        public static SektorskaZanimanjaDjelatnostiDTO MockDjelatnosti()
        {
            var response = new SektorskaZanimanjaDjelatnostiDTO();
            Random r = new Random();

            response.MuskarciSektor = r.Next(0, 700);
            response.MuskarciUkupno = r.Next(0, 700);
            response.ZeneSektor = r.Next(0, 700);
            response.ZeneUkupno = r.Next(0, 700);
            response.Ukupno = r.Next(0, 3500);
            response.UkupnoSektor = r.Next(0, 700);

            return response;
        }
    }
}
