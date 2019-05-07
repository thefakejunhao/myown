using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Our_FYPJ2019.DAL.Startup))]

namespace Our_FYPJ2019.DAL
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
