using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MvcApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
//The type 'System.Net.Http.HttpMessageHandler' is defined in an assembly that is not referenced. 
//You must add a reference to assembly 'System.Net.Http, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
