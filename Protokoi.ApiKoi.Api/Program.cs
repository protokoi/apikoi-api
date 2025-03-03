using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using Protokoi.ApiKoi.Api.Helpers;
using Protokoi.ApiKoi.Core.Shared.Mapping;
using Protokoi.ApiKoi.Data;

var builder = WebApplication.CreateBuilder(args);

ConfigureDi(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.Init();

app.MapControllers();

app.UseHttpsRedirection();

app.Run();


void ConfigureDi(WebApplicationBuilder builder)
{
	ConfigureApiVersioning();

	builder.Services.AddControllers();
	builder.Services.AddEndpointsApiExplorer();
	builder.Services.AddSwaggerGen();

	builder.Services.AddDbContext<ApplicationDbContext>(options =>
	{
		options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
	});

	builder.Services.ConfigureMapping();


	void ConfigureApiVersioning()
	{
		// Configure API versioning
		builder.Services.AddApiVersioning(x =>
		{
			x.AssumeDefaultVersionWhenUnspecified = true;
			x.DefaultApiVersion = ApiVersion.Default;
			x.ReportApiVersions = true;
			x.ApiVersionReader = ApiVersionReader.Combine(
				new QueryStringApiVersionReader("api-version"),
				new HeaderApiVersionReader("api-version"),
				new UrlSegmentApiVersionReader()
			);
		}).AddApiExplorer(x =>
		{
			x.GroupNameFormat = "'v'V";
			x.SubstituteApiVersionInUrl = true;
		});
	}
}