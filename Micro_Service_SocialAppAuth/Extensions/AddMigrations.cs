using Microsoft.EntityFrameworkCore;
using MicroServiceAuthentication.Data;

namespace MicroServiceAuthentication.Extensions
{
    public static class AddMigrations
    {
        public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
        {

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var _db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }

            return app;
        }
    }
}
