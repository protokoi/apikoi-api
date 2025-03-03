using System.ComponentModel.DataAnnotations;
using Protokoi.ApiKoi.Core.Shared.Models;

namespace Protokoi.ApiKoi.Data.Entities;

public sealed class Post : AuditedEntity
{
	[MaxLength(63)] public string? CategoryName { get; set; }
	[MaxLength(63)] public string? Title { get; set; }
	[MaxLength(4096)] public string? Content { get; set; }
	[MaxLength(255)] public string? Summary { get; set; }
	[MaxLength(255)] public string? ImageUrl { get; set; }
	[MaxLength(255)] public string? VideoUrl { get; set; }
	[MaxLength(255)] public string? AudioUrl { get; set; }
	public List<string>? Tags { get; set; }
	public bool IsPublished { get; set; }
	public DateTime? PublishedAt { get; set; }
	public bool IsFeatured { get; set; }
	public int Views { get; set; }
	public int Likes { get; set; }
	public int Dislikes { get; set; }
	public int Comments { get; set; }
}