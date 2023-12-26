﻿using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(Letragames.MVC.App_Start.Startup1))]

namespace Letragames.MVC.App_Start
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions() { 
            
            AuthenticationType = "ApplicationCookie",
            LoginPath = new PathString("/Account/Login")
            
            } );
        }
    }
}

