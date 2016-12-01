using System.Collections.Generic;
using HKO.BLL.Managers.Lookups;
using HKO.Models.DTOs.Sektori;
using HKO.Models.Sektori;

namespace HKO.BLL.Handlers.Sektori
{
    public static class ZaposelnostUdjelHandler
    {
        public static List<ZaposlenostUdjelDTO> MapZaposlenostUdjelToDto(IEnumerable<ZaposlenostUdjel> items)
        {
            var response = new List<ZaposlenostUdjelDTO>();

            foreach (var item in items)
            {
                ZaposlenostUdjelDTO newItem = new ZaposlenostUdjelDTO();
                newItem.RodID = item.Rod;
                newItem.Sektor = item.SEKZU;
                newItem.Ukupno = item.UKZ;

                response.Add(newItem);
            }

            return response;
        }

        public static List<ZaposlenostUdjelDTO> MapNezaposlenostUdjelToDto(IEnumerable<ZaposlenostUdjel> items)
        {
            var response = new List<ZaposlenostUdjelDTO>();

            var lookupsManager = new LookupsManager();
            //var rodovi = lookupsManager.getr


            foreach (var item in items)
            {
                ZaposlenostUdjelDTO newItem = new ZaposlenostUdjelDTO();
                newItem.RodID = item.Rod;
                newItem.Sektor = item.SEKNU;
                newItem.Ukupno = item.UKN;

                response.Add(newItem);
            }

            return response;
        }
    }
}
