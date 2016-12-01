using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HKO.API.Controllers
{
    public class TestController : ApiController
    {
        /// <summary>
        /// Test method to see if help pages work
        /// </summary>
        /// <param name="temp">Temp param</param>
        /// <returns></returns>
        public string GetTest(int temp)
        { 
            return "bubu";
        }
    }
}
