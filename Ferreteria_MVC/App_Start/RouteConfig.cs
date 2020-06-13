using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ferreteria_MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Categorias",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Categorias", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "DetallaVentas",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "DetalleVentas", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Empleados",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Empleadoes", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Facturas",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Facturas", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Personas",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Personas", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Productos",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Productoes", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "TipoPago",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "TipoPagoes", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Ventas",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Ventas", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
