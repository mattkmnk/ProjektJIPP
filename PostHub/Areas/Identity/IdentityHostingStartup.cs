using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostHub.Areas.Identity.Data;
using PostHub.Data;

[assembly: HostingStartup(typeof(PostHub.Areas.Identity.IdentityHostingStartup))]
namespace PostHub.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<PostHubContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("PostHubContextConnection")));

                services.AddDefaultIdentity<PostHubUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<PostHubContext>();
            });
        }
    }
}