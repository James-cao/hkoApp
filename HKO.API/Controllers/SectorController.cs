using System.Linq;
using System.Web.Http;
using HKO.BLL.Managers.Sektori;

namespace HKO.API.Controllers
{
    /// <summary>
    /// Sector details
    /// </summary>
    public class SectorController : ApiController
    {
        private SektoriManager sektorManager = new SektoriManager();
        
        #region Pregled Sektora

        /// <summary>
        /// Broj sektorskih zanimanja prema rodovima i obrazovnih programa prema razinama HKO
        /// </summary>
        /// <param name="sifraSektora"></param>
        /// <returns></returns>
        [Route("api/sektor/{sifraSektora}/podsektor/{sifraPodsektora}/zanimanja_prema_rodovima")]
        [HttpGet]
        public IHttpActionResult GetSektorskaZanimanjaPremaRodovima(string sifraSektora, string sifraPodsektora)
        {
            var response = sektorManager.GetSektorskaZanimanjaPremaRodovima(sifraSektora, sifraPodsektora).ToList();

            return Ok(response);
        }

        /// <summary>
        /// Udio sektora u ukupnoj radnoj snazi RH
        /// </summary>
        /// <param name="sifraSektora"></param>
        /// <param name="sifraPodsektora"></param>
        /// <param name="mjesec"></param>
        /// <param name="godina"></param>
        /// <returns></returns>
        [Route("api/sektor/{sifraSektora}/podsektor/{sifraPodsektora}/radna_snaga/{mjesec}/{godina}")]
        [HttpGet]
        public IHttpActionResult GetSektorRadnaSnaga(string sifraSektora, int mjesec, int godina, string sifraPodsektora = null)
        {
            var response = sektorManager.GetSektorRadnaSnaga(sifraSektora, mjesec, godina, sifraPodsektora);

            return Ok(response);
        }

        /// <summary>
        /// Udio podsektora u radnoj snazi sektora
        /// </summary>
        /// <param name="sifraSektora"></param>
        /// <param name="mjesec"></param>
        /// <param name="godina"></param>
        /// <returns></returns>
        [Route("api/sektor/{sifraSektora}/udio_podsektora/{mjesec}/{godina}")]
        [HttpGet]
        public IHttpActionResult GetPodsektoriUSektoru(string sifraSektora, int mjesec, int godina)
        {
            var response = sektorManager.GetPodsektoriUSektoru(sifraSektora, mjesec, godina);

            return Ok(response);
        }

        /// <summary>
        /// Raspršenost sektorskih zanimanja po djelatnostima
        /// </summary>
        /// <param name="sifraSektora"></param>
        /// <param name="mjesec"></param>
        /// <param name="godina"></param>
        /// <param name="zupanijaID"></param>
        /// <returns></returns>
        [Route("api/sektor/{sifraSektora}/po_djelatnostima/{mjesec}/{godina}/{zupanijaID}")]
        [HttpGet]
        public IHttpActionResult GetSektorskaZanimanjaDjelatnosti(string sifraSektora, int mjesec, int godina, string zupanijaID = null)
        {
            var response = sektorManager.GetSektorskaZanimanjaDjelatnosti(sifraSektora, mjesec, godina, zupanijaID);

            return Ok(response);
        }

        /// <summary>
        /// Broj sektorskih zanimanja u odnosu na ukupan broj zanimanja u RH
        /// </summary>
        /// <param name="sifraSektora"></param>
        /// <returns></returns>
        [Route("api/sektor/{sifraSektora}/zanimanja_ukupan_broj")]
        [HttpGet]
        public IHttpActionResult GetSektorskaZanimanjaRH(string sifraSektora)
        {
            var response = sektorManager.GetBrojSektorskihZanimanjaRH(sifraSektora);

            return Ok(response);
        }

        #endregion


        #region Osnovni Podaci

        /// <summary>
        /// Broj zaposlenih i nezaposlenih u HR u sektoru prema spolu - 8/2016
        /// </summary>
        /// <param name="sifraSektora">-1 or real value; cannot combine with sifraPodsektora</param>
        /// <param name="sifraPodsektora">-1 or real value</param>
        /// <param name="mjesec"></param>
        /// <param name="godina"></param>
        /// <param name="zupanijaID"></param>
        /// <returns></returns>
        [Route("api/sektor/{sifraSektora}/podsektor/{sifraPodsektora}/zaposlenost_broj/{mjesec}/{godina}/{zupanijaID}")]
        [HttpGet]
        public IHttpActionResult GetSektorBrojZapNezap(string sifraSektora,string sifraPodsektora, int mjesec, int godina, string zupanijaID = null)
        {
            var response = sektorManager.GetZaposlenostBroj(sifraSektora, mjesec, godina, sifraPodsektora, zupanijaID);
            
            return Ok(response);
        }

        /// <summary>
        /// Stopa nezaposlenosti u RH u sektoru prema spolu 
        /// </summary>
        /// <param name="sifraSektora"></param>
        /// <param name="sifraPodsektora"></param>
        /// <param name="mjesec"></param>
        /// <param name="godina"></param>
        /// <param name="zupanijaID"></param>
        /// <returns></returns>
        [Route("api/sektor/{sifraSektora}/podsektor/{sifraPodsektora}/zaposlenost_stopa/{mjesec}/{godina}/{zupanijaID}")]
        [HttpGet]
        public IHttpActionResult GetSektorStopaZapNezap(string sifraSektora, string sifraPodsektora, int mjesec, int godina, string zupanijaID = null)
        {
            var response = sektorManager.GetZaposlenostStopa(sifraSektora, mjesec, godina,sifraPodsektora, zupanijaID);

            return Ok(response);
        }

        /// <summary>
        /// Udjeli zaposlenih po rodovima zanimanja u sektoru i RH, %
        /// </summary>
        /// <param name="sifraSektora"></param>
        /// <param name="sifraPodsektora"></param>
        /// <param name="mjesec"></param>
        /// <param name="godina"></param>
        /// <param name="zupanijaID"></param>
        /// <returns></returns>
        [Route("api/sektor/{sifraSektora}/podsektor/{sifraPodsektora}/zaposlenost_udjeli/{mjesec}/{godina}/{zupanijaID}")]
        [HttpGet]
        public IHttpActionResult GetSektorUdjeliZapRodovi(string sifraSektora, string sifraPodsektora, int mjesec, int godina, string zupanijaID = null)
        {
            var response = sektorManager.GetZaposlenostUdjeliRodovi(sifraSektora, mjesec, godina, sifraPodsektora, zupanijaID);

            return Ok(response);
        }

        /// <summary>
        /// Udjeli nezaposlenih po rodovima zanimanja u sektoru i RH, %
        /// </summary>
        /// <param name="sifraSektora"></param>
        /// <param name="sifraPodsektora"></param>
        /// <param name="mjesec"></param>
        /// <param name="godina"></param>
        /// <param name="zupanijaID"></param>
        /// <returns></returns>
        [Route("api/sektor/{sifraSektora}/podsektor/{sifraPodsektora}/nezaposlenost_udjeli/{mjesec}/{godina}/{zupanijaID}")]
        [HttpGet]
        public IHttpActionResult GetSektorUdjeliNeZapRodovi(string sifraSektora, string sifraPodsektora, int mjesec, int godina, string zupanijaID = null)
        {
            var response = sektorManager.GetNezaposlenostUdjeliRodovi(sifraSektora, mjesec, godina, sifraPodsektora, zupanijaID);

            return Ok(response);
        }


        /// <summary>
        /// Obuhvat sektora prema radnoj snazi po županijama i spolu 
        /// </summary>
        /// <param name="sifraSektora"></param>
        /// <param name="sifraPodsektora"></param>
        /// <param name="mjesec"></param>
        /// <param name="godina"></param>
        /// <returns></returns>
        [Route("api/sektor/{sifraSektora}/podsektor/{sifraPodsektora}/obuhvat/{mjesec}/{godina}")]
        [HttpGet]
        public IHttpActionResult GetObuhvatSektora(string sifraSektora, string sifraPodsektora, int mjesec, int godina)
        {
            var response = sektorManager.GetObuhvatSektora(sifraSektora, mjesec, godina, sifraPodsektora);

            return Ok(response);
        }

        /// <summary>
        /// Ključne djelatnosti po rodovima zanimanja u sektoru 
        /// </summary>
        /// <param name="sifraSektora"></param>
        /// <param name="sifraPodsektora"></param>
        /// <param name="mjesec"></param>
        /// <param name="godina"></param>
        /// <param name="zupanijaID"></param>
        /// <returns></returns>
        [Route("api/sektor/{sifraSektora}/podsektor/{sifraPodsektora}/kljuc_djel/{mjesec}/{godina}/{zupanijaID}")]
        [HttpGet]
        public IHttpActionResult GetKljucneDjelatnosti(string sifraSektora, string sifraPodsektora, int mjesec, int godina, string zupanijaID = null)
        {
            var response = sektorManager.GetKljucneDjelatnosti(sifraSektora, mjesec, godina, sifraPodsektora, zupanijaID);

            return Ok(response);
        }
        #endregion
        

        #region Dob

        [Route("api/sektor/{sifraSektora}/podsektor/{sifraPodsektora}/dob/{mjesec}/{godina}/{zupanijaID}/{rod}")]
        [HttpGet]
        public IHttpActionResult GetSektorDob(string sifraSektora, string sifraPodsektora, int mjesec, int godina, string zupanijaID = null, string rod=null)
        {
            var response = sektorManager.GetSektorDob(sifraSektora, mjesec, godina, sifraPodsektora, zupanijaID,rod);

            return Ok(response);
        }


        #endregion


        #region Zapošljavanje u ključnim djelatnostima

        /// <summary>
        /// Zapošljavanje u ključnim djelatnostima
        /// </summary>
        /// <param name="godinaOd"></param>
        /// <param name="godinaDo"></param>
        /// <param name="mjesec"></param>
        /// <param name="djelatnost">Može biti 1,2,3</param>
        /// <returns></returns>
        [Route("api/sektor/zap_kljuc_djel/{mjesec}/{godinaOd}/{godinaDo}/{djelatnost}")]
        [HttpGet]
        public IHttpActionResult GetZaposljavanjeKljucDjel(string godinaOd, string godinaDo, string mjesec, string djelatnost)
        {
            var response = sektorManager.GetZaposljavanjeKljucDjelatnosti(godinaOd, godinaDo, mjesec, djelatnost);

            return Ok(response);
        }


        #endregion
    }
}
