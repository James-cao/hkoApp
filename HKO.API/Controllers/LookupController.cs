using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HKO.API.Filters;
using HKO.BLL;
using HKO.BLL.Managers.Lookups;
using HKO.Models.DTOs.Lookups;
using HKO.Models.Lookups;

namespace HKO.API.Controllers
{
    /// <summary>
    /// Lookups used in HKO portal
    /// </summary>


    public class LookupController : ApiController
    {
        private LookupsManager lookupManager = new LookupsManager();

        /// <summary>
        /// Gets all županije
        /// </summary>
        /// <returns></returns>
        [Route("api/lookup/zupanije")]
        [HttpGet]
        public IHttpActionResult GetZupanije()
        {
            var response = lookupManager.GetZupanije().ToList();

            return Ok(response);
        }

        /// <summary>
        /// Gets županija by ID županije
        /// </summary>
        /// <returns></returns>
        [Route("api/lookup/zupanije/{id}")]
        [HttpGet]
        public IHttpActionResult GetZupanijeByID(int ID)
        {
            var response = lookupManager.GetZupanijeByID(ID);

            return Ok(response);
        }


        /// <summary>
        /// Gets all ugovori o radu
        /// </summary>
        /// <returns></returns>
        [Route("api/lookup/ugovor_o_radu")]
        [HttpGet]
        public IHttpActionResult GetUgovorORadu()
        {
            var response = lookupManager.GetUgovorORadu().ToList();

            return Ok(response);
        }

       /// <summary>
       /// Gets ugovor o radu by ID
       /// </summary>
       /// <param name="ID"></param>
       /// <returns></returns>
        [Route("api/lookup/ugovor_o_radu/{id}")]
        [HttpGet]
        public IHttpActionResult GetUgovorORaduByID(int ID)
        {
           var response = lookupManager.GetUgovorORaduByID(ID);

           return Ok(response);
        }



        /// <summary>
        /// Gets all stručno obrazovanje
        /// </summary>
        /// <returns></returns>
        [Route("api/lookup/strucno_obrazovanje")]
        [HttpGet]
        public IHttpActionResult GetStrucnoObrazovanje()
        {
            var response = lookupManager.GetStrucnoObrazovanje().ToList();

            return Ok(response);
        }

        /// <summary>
        /// Gets stručno obrazovanje by ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [Route("api/lookup/strucno_obrazovanje/{id}")]
        [HttpGet]
        public IHttpActionResult GetStrucnoObrazovanjeByID(int ID)
        {
            var  response = lookupManager.GetStrucnoObrazovanjeByID(ID);

            return Ok(response);
        }



        /// <summary>
        /// Gets all NKZ98 elements
        /// </summary>
        /// <returns></returns>
        [Route("api/lookup/nkz98")]
        [HttpGet]
        public IHttpActionResult GetNkz98()
        {
            var response = lookupManager.GetNkz98().ToList();

            return Ok(response);
        }

        /// <summary>
        /// Gets NKZ98 element by ID
        /// </summary>
        /// <param name="ID">Must be sent in format XXXX_XX_X</param>
        /// <returns></returns>
        [Route("api/lookup/nkz98/{id}")]
        [HttpGet]
        public IHttpActionResult GetNkz98ByID(string ID)
        {
            var response = lookupManager.GetNkz98ByID(ID);

            return Ok(response);
        }


        /// <summary>
        /// Gets all NKZ7 elements
        /// </summary>
        /// <returns></returns>
        [Route("api/lookup/nkz7")]
        [HttpGet]
        public IHttpActionResult GetNkz7()
        {
           var response = lookupManager.GetNkz7().ToList();

           return Ok(response);
        }

        /// <summary>
        /// Gets NKZ7 element by ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [Route("api/lookup/nkz7/{id}")]
        [HttpGet]
        public IHttpActionResult GetNkz7ByID(string ID)
        {
            var response = lookupManager.GetNkz7ByID(ID);

            return Ok(response);
        }



        /// <summary>
        /// Gets all HKO šifre elements
        /// </summary>
        /// <returns></returns>
        [Route("api/lookup/hko_sifre")]
        [HttpGet]
        public IHttpActionResult GetHkoSifre()
        {
            var response = lookupManager.GetHkoSifre().ToList();

            return Ok(response);
        }


        /// <summary>
        /// Gets HKO sifre element by ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [Route("api/lookup/hko_sifre/{id}")]
        [HttpGet]
        public IHttpActionResult GetHkoSifreByID(string ID)
        {
            var response = lookupManager.GetHkoSifreByID(ID);
            
            return Ok(response);
        }



        /// <summary>
        /// Gets gradovi and općine
        /// </summary>
        /// <returns></returns>
        [Route("api/lookup/gradovi_opcine")]
        [HttpGet]
        public IHttpActionResult GetGradoviOpcine()
        {
            var response = lookupManager.GetGradoviOpcine().ToList();
            
            return Ok(response);
        }

        /// <summary>
        /// Gets grad or općina by ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [Route("api/lookup/gradovi_opcine/{id}")]
        [HttpGet]
        public IHttpActionResult GetGradoviOpcineByID(int ID)
        {
            var response = lookupManager.GetGradoviOpcineByID(ID);

            return Ok(response);
        }

        /// <summary>
        /// Gets gradovi and općine in županija by ŽupanijaID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [Route("api/lookup/gradovi_opcine/zupanija/{zupanijaID}")]
        [HttpGet]
        public IHttpActionResult GetGradoviOpcineByZupanijaID(int zupanijaID)
        {
            var response = lookupManager.GetGradoviOpcineByZupanijaID(zupanijaID).ToList();
            
            return Ok(response);
        }

        /// <summary>
        /// Gets HKO Rodovi
        /// </summary>
        /// <returns></returns>
        [Route("api/lookup/rodovi")]
        [HttpGet]
        public IHttpActionResult GetRodovi()
        {
            var response = lookupManager.GetRodovi().ToList();

            return Ok(response);
        }

        /// <summary>
        /// Gets Ključne djelatnosti
        /// </summary>
        /// <returns></returns>
        [Route("api/lookup/kljuc_djel")]
        [HttpGet]
        public IHttpActionResult GetKljucneDjelatnosti()
        {
            var response = lookupManager.GetKljucneDjelatnosti().ToList();

            return Ok(response);
        }

        /// <summary>
        /// Gets default month and year for DB queries
        /// </summary>
        /// <returns></returns>
        [Route("api/lookup/month_year")]
        [HttpGet]
        public IHttpActionResult GetDefaultMonthYear()
        {
            var response = lookupManager.GetDefaultTimeframe();
            return Ok(response);
        }
    }
}
