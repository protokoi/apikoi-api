using Microsoft.EntityFrameworkCore;
using Protokoi.ApiKoi.Data.Entities;
using Protokoi.ApiKoi.Data.Middlewares;

namespace Protokoi.ApiKoi.Data;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
	public DbSet<Category> Categories { get; set; }
	public DbSet<Post> Posts { get; set; }
	public DbSet<User> Users { get; set; }
	public DbSet<Comment> Comments { get; set; }
	public DbSet<Todo> Todos { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.AddInterceptors(new AuditedEntityInterceptor());
		base.OnConfiguring(optionsBuilder);
	}
}