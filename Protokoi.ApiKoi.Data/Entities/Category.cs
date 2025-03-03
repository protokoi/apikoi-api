using System.ComponentModel.DataAnnotations;
using Protokoi.ApiKoi.Core.Shared.Models;

namespace Protokoi.ApiKoi.Data.Entities;

public sealed class Category : AuditedEntity
{
	[MaxLength(63)]
	public required string Name { get; set; }
	[MaxLength(255)]
	public string? Description { get; set; }
}