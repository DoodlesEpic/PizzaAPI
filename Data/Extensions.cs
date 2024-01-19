using System.Security;

namespace PizzaAPI.Data;

public static class Extensions
{
    public static void CreateDbIfEmpty(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<PizzaContext>();
        context.Database.EnsureCreated();
        DbInitializer.Initialize(context);
    }
}
