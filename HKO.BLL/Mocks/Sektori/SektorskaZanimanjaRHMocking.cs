using HKO.Models.Sektori;

namespace HKO.BLL.Mocks.Sektori
{
    public static class SektorskaZanimanjaRHMocking
    {
        public static SektorskaZanimanjaRH MockSektorskaZanimanjaRH()
        {
            var mockResponse = new SektorskaZanimanjaRH();

            mockResponse.SektorBroj = 351;
            mockResponse.SektorPostotak=8.32;
            mockResponse.UkupnoBroj = 3869;
            mockResponse.UkupnoPostotak = 91.68;

            return mockResponse;
        }
    }
}
