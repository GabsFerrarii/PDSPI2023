using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using WebAppProjeto2023_2.Areas.Seguranca.Data;
using System.Data.Entity;

namespace WebAppProjeto2023_2.DAL
{
    public class IdentityDbContextAplicacao : IdentityDbContext<Usuario>
    {
        public IdentityDbContextAplicacao() : base("IdentityDb")
        { }
        static IdentityDbContextAplicacao()
        {
            Database.SetInitializer<IdentityDbContextAplicacao>(
            new IdentityDbInit());
        }
        public static IdentityDbContextAplicacao Create()
        {
            return new IdentityDbContextAplicacao();
        }
        public class IdentityDbInit : DropCreateDatabaseIfModelChanges<IdentityDbContextAplicacao>
        {

        }
    }
}
