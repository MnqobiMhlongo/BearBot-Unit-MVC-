using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(signalRxGemini.Startup))]
namespace signalRxGemini
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
