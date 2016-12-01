using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace HKO.API.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (ConfigurationManager.AppSettings["isLogging"] == "true")
            {
               
                var actionContext = actionExecutedContext.ActionContext;
                var browser = HttpContext.Current.Request.Browser.Browser;

             
            actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);

            //loggerMan.LogServiceRequest(actionContext.RequestContext.Principal.Identity.Name,
            //    actionContext.ActionDescriptor.ActionName + " - EXCEPTION", 1,
            //    Helpermethods.GetClientIp(HttpContext.Current.Request.Headers["X-Forwarded-For"],
            //        HttpContext.Current.Request.UserHostAddress), System.Environment.MachineName,
            //    actionContext.Request.RequestUri.ToString(), "MESSAGE: " + actionExecutedContext.Exception.Message + " ---- " + actionExecutedContext.Exception.StackTrace + " ---- INNER:" + actionExecutedContext.Exception.InnerException,
            //    "ApiException", browser);
                
            }

        }
    }
}