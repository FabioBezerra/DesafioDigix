using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Infra.MockedData
{
    public static class Startup
    {
        public static void RunMigration<T>(IApplicationBuilder app) where T : DbContext
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<T>();
                context.Database.SetCommandTimeout(3 * 1000);
                context.Database.Migrate();
            }
        }
    }
}
