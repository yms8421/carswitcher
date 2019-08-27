using Microsoft.Owin;
using Owin;
[assembly: OwinStartup(typeof(BilgeAdam.CardSwitcher.Helpers.Startup))]
namespace BilgeAdam.CardSwitcher.Helpers
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}