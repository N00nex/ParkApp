using Microsoft.EntityFrameworkCore;
using ParkAPI.Data;


namespace ParkAPI.Helpers
{
    public static class DatabaseHelper
    {
        private static IServiceProvider _serviceProvider;

        public static void Initialize(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static async Task<List<T>> GetAll<T>(CancellationToken ct) where T : class
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                return await context.Set<T>().AsNoTracking().ToListAsync(ct);
            }
        }
    }
}