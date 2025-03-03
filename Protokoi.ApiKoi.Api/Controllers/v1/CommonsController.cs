using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Protokoi.ApiKoi.Api.Controllers.v1
{
	[ApiController]
	[ApiVersion(1)]
	[Route("api/v{version:ApiVersion}/[controller]")]
	public sealed class CommonsController : ControllerBase
	{
		[HttpGet]
		public IActionResult Get()
		{
			return Ok("Hello from API v1");
		}
	}
}
