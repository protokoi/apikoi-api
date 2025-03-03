using System.ComponentModel.DataAnnotations;
using Protokoi.ApiKoi.Core.Shared.Models;

namespace Protokoi.ApiKoi.Data.Entities;

public sealed class Todo : AuditedEntity
{
	[MaxLength(63)] public string? Title { get; set; }
	[MaxLength(255)] public string? Description { get; set; }
	public bool Completed { get; set; }
	public DateTime? DueDate { get; set; }
}