using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Protokoi.ApiKoi.Core.Shared.Models;

namespace Protokoi.ApiKoi.Data.Middlewares;

public class AuditedEntityInterceptor : SaveChangesInterceptor
{
	public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
	{
		UpdateAuditFields(eventData.Context);
		return base.SavingChanges(eventData, result);
	}

	public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
		InterceptionResult<int> result, CancellationToken cancellationToken = default)
	{
		UpdateAuditFields(eventData.Context);
		return base.SavingChangesAsync(eventData, result, cancellationToken);
	}

	private static void UpdateAuditFields(DbContext? context)
	{
		if (context == null)
		{
			return;
		}

		var entries = context.ChangeTracker
			.Entries<AuditedEntity>()
			.Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

		foreach (var entry in entries)
		{
			var now = DateTime.UtcNow;
			if (entry.State == EntityState.Added)
			{
				entry.Entity.CreatedAt = now;
			}

			entry.Entity.LastModifiedAt = now;
		}
	}
}