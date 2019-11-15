using System;
using HomeBodyACG.Areas.Identity.Data;
using HomeBodyACG.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(HomeBodyACG.Areas.Identity.IdentityHostingStartup))]
namespace HomeBodyACG.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<HomeBodyACGContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("HomeBodyACGContextConnection")));

                services.AddDefaultIdentity<HomeBodyACGUser>()
                    .AddEntityFrameworkStores<HomeBodyACGContext>();
            });
        }
    }
}