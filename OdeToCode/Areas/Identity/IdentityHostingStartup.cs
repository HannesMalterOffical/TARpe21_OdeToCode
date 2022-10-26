using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OdeToCode.Data;

[assembly: HostingStartup(typeof(OdeToCode.Areas.Identity.IdentityHostingStartup))]
namespace OdeToCode.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<OdeToCodeContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("OdeToCodeContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<OdeToCodeContext>();
            });
        }
    }
}