using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sagardemoapi.filters
{
    public class tokenverify : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
          
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var headers = context.HttpContext.Request.Headers;
            var tokenvalue = headers["tokenheader"];


            if (tokenvalue == "youtube.outtm.com")//static rule
            {
                // return ok,,,
            }
            else
            {
                // return unauthorize
                context.HttpContext.Response.StatusCode = 401; // code is coming from here
                // reason is coming from below line
                context.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "Invalid Token";

                // body message is coming from below 2 lines.,,, cool
                byte[] responsetext = Encoding.ASCII.GetBytes("INVALID RESPONSE BECAUSE OF WRONG TOKEN");
                context.HttpContext.Response.Body.WriteAsync(responsetext);
            }
        }
    }
}
