using Microsoft.EntityFrameworkCore;
using Protokoi.ApiKoi.Data;
using Protokoi.ApiKoi.Data.Helpers;

namespace Protokoi.ApiKoi.Api.Helpers;

public static class InitializeDbContext
{
	public static void Init(this WebApplication app)
	{
		using var scope = app.Services.CreateScope();
		var services = scope.ServiceProvider;
		var context = services.GetRequiredService<ApplicationDbContext>();

		context.Database.EnsureCreated();
		
		context.Database.Migrate();

		context.SeedData();
	}
}