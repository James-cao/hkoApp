using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HKO.Models.DTOs.Sektori;
using HKO.Models.Sektori;

namespace HKO.BLL.Mocks.Sektori
{
    public static class SektorskaZanimanjaRodoviMocking
    {
        public static List<SektorskaZanimanjaRodoviDTO> MockObrazovni(List<SektorskaZanimanjaRodovi> list)
        {
            var response = new List<SektorskaZanimanjaRodoviDTO>();

            foreach (var item in list)
            {
                var itemDTO = new SektorskaZanimanjaRodoviDTO();

                itemDTO.Rod = item.Rod;
                itemDTO.ValueZanimanja = item.Value;

                Random r = new Random();
                itemDTO.ValueProgrami = r.Next(0, 100);

                response.Add(itemDTO);
            }

            return response;
        }
    }
}
