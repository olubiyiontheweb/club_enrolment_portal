using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheKangaroos_ClubEnrolmentPortal.Data;
using TheKangaroos_ClubEnrolmentPortal.Data.Models;

[assembly: HostingStartup(typeof(TheKangaroos_ClubEnrolmentPortal.Areas.Identity.IdentityHostingStartup))]
namespace TheKangaroos_ClubEnrolmentPortal.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}