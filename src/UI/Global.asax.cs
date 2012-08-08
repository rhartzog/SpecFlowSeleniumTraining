﻿using System.Web.Mvc;
using System.Web.Routing;

namespace UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "WidgetsIndex",
                url: "widgets/{id}",
                defaults: new { controller = "Widget", action = "Index" });

            routes.MapRoute(
                name: "WidgetsList",
                url: "widgets",
                defaults: new { controller = "Widget", action = "List" });

            routes.MapRoute(
                name: "WidgetsEdit",
                url: "widgets/edit/{id}",
                defaults: new { controller = "Widget", action = "Edit" });

            routes.MapRoute(
                name: "WidgetsDelete",
                url: "widgets/delete/1",
                defaults: new { controller = "Widget", action = "Delete" });

            routes.MapRoute(
                name: "WidgetsCreate",
                url: "widgets/create",
                defaults: new { controller = "Widget", action = "Create" });

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}