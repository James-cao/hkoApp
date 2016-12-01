using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HKO.Models.DTOs.Lookups;
using HKO.Models.Lookups;

namespace HKO.BLL.Handlers.Lookups
{
    public class HkoSifreHandler
    {

        internal static IList<HkoSifreDTO> MapHkoSifreToDtO(IEnumerable<HkoSifre> items)
        {
            var levelOneItems = items.Where(x => x.Razina_Sifre == 1);
            var levelTwoItems = items.Where(x => x.Razina_Sifre == 2);
            var levelThreeItems = items.Where(x => x.Razina_Sifre == 3);

            var levelThreeDTOs = levelThreeItems.Select(lev3Item => new HkoSifreDTO
            {
                ID = lev3Item.Sifra, Naziv = lev3Item.Naziv, Podsektori = null
            }).ToList();

            var levelTwoDTOs = levelTwoItems.Select(lev2Item => new HkoSifreDTO
            {
                ID = lev2Item.Sifra,
                Naziv = lev2Item.Naziv,
                Podsektori = null
            }).ToList();

            var levelOneDTOs = levelOneItems.Select(lev1Item => new HkoSifreDTO
            {
                ID = lev1Item.Sifra,
                Naziv = lev1Item.Naziv,
                Podsektori = null
            }).ToList();

            foreach (var item2 in levelTwoDTOs)
            {
                item2.Podsektori = levelThreeDTOs.Where(i=>i.ID.Substring(0, 3) == item2.ID.Substring(0, 3)).ToList();
            }

            foreach (var item1 in levelOneDTOs)
            {
                item1.Podsektori = levelTwoDTOs.Where(i => i.ID.Substring(0, 2) == item1.ID.Substring(0, 2)).ToList();
            }

            return levelOneDTOs;
        }
    }
}
