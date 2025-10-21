using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace DiscountGRPC.Data
{
    public static class Extensions
    {
        public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<DiscountContext>())
                {
                    context.Database.MigrateAsync();
                }
                    
            }
            return app;
        }
    }
}
