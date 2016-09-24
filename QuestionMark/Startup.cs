using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuestionMark.Startup))]
namespace QuestionMark
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
