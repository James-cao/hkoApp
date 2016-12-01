using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HKO.Models.DTOs.Sektori;
using HKO.Models.Sektori;

namespace HKO.BLL.Handlers.Sektori
{
    public static class ZaposlenostBrojHandler
    {
        public static ZaposlenostBrojDTO MapZaposlenostBrojToDto(IEnumerable<ZaposlenostBroj> items)
        {
            var response = new ZaposlenostBrojDTO();

            foreach (var item in items)
            {
                response.M_Zap += item.ZM;
                response.M_Nezap += item.NM;
                response.F_Zap += item.ZF;
                response.F_Nezap += item.NF;
                response.Uk_Zap += item.ZU;
                response.Uk_Nezap += item.NU;

            }

            return response;
        }

    }
}
