using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DotNetNuke.Web.Api;

namespace TAC.Modules.HelloWorld.Services
{
    public class RouterMapper:IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute(
            "TAC_HelloWorld",
            "default",
            "{controller}/{action}",
            new string[] { "TAC.Modules.HelloWorld.Services" });
        }
    }
}