using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using MVC5Course.Models;

namespace MVC5Course
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 設定和服務
            //ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            //builder.EntitySet<Product>("ProductsAPI");
            //builder.EntitySet<OrderLine>("OrderLine");
            //config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
