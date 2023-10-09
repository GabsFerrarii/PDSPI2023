using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppProjeto2023_2.Areas.Seguranca.Data;
using WebAppProjeto2023_2.DAL;

namespace WebAppProjeto2023_2.Infraestrutura
{
    public class GerenciadorPapel : RoleManager<Papel>, IDisposable
    {
        public GerenciadorPapel(RoleStore<Papel> store) : base(store)
        {
        }
        public static GerenciadorPapel Create(IdentityFactoryOptions
        <GerenciadorPapel> options, IOwinContext context)
        {
            return new GerenciadorPapel(new RoleStore<Papel>
            (context.Get<IdentityDbContextAplicacao>()));
        }
    }
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IdentityDbContextAplicacao>
            (IdentityDbContextAplicacao.Create);
            app.CreatePerOwinContext<GerenciadorUsuario>
            (GerenciadorUsuario.Create);
            app.CreatePerOwinContext<GerenciadorPapel>
            (GerenciadorPapel.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Seguranca/Account/Login"),
            });
        }
    }
}