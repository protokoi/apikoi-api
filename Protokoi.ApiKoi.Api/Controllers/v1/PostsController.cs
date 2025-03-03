using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Protokoi.ApiKoi.Api.Controllers.v1;

[ApiController]
[ApiVersion(1)]
[Route("api/v{version:apiVersion}/[controller]")]
public sealed class PostsController : Controller
{
}