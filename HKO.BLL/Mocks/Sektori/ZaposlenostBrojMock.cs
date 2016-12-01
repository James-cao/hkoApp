using System;
using HKO.Models.Sektori;

namespace HKO.BLL.Mocks.Sektori
{
    public static class ZaposlenostBrojMock
    {
        public static ZaposlenostBroj GetZaposlenostBrojMock()
        {
            var response = new ZaposlenostBroj();
            Random r = new Random();

            //response.M_Zap = r.Next(0,20000);
            //response.F_Zap = r.Next(0, 20000);
            //response.M_Nezap = r.Next(0, 20000);
            //response.F_Nezap = r.Next(0, 20000);
            //response.Uk_Zap = response.M_Zap + response.F_Zap;
            //response.Uk_Nezap = response.M_Nezap + response.F_Nezap;

            return response;
        }

        public static ZaposlenostBroj GetZaposlenostStopaMock()
        {
            var response = new ZaposlenostBroj();
            Random r = new Random();

            //response.M_Zap = r.NextDouble()*100;
            //response.F_Zap = r.NextDouble() * 100;
            //response.M_Nezap = r.NextDouble() * 100;
            //response.F_Nezap = r.NextDouble() * 100;
            //response.Uk_Zap = response.M_Zap + response.F_Zap;
            //response.Uk_Nezap = response.M_Nezap + response.F_Nezap;

            return response;
        }
    }
}
