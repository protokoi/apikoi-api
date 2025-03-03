namespace Protokoi.ApiKoi.Core.Shared.Models;

public class AuditedEntity : Entity
{
	public string? CreatedBy { get; set; }
	public DateTime CreatedAt { get; set; }
	public string? LastModifiedBy { get; set; }
	public DateTime? LastModifiedAt { get; set; }
}