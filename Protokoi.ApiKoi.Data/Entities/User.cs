using System.ComponentModel.DataAnnotations;
using Protokoi.ApiKoi.Core.Shared.Models;

namespace Protokoi.ApiKoi.Data.Entities;

public sealed class User : AuditedEntity
{
	[MaxLength(63)] public string? FirstName { get; set; }
	[MaxLength(63)] public string? LastName { get; set; }
	[MaxLength(63)] public string? MiddleName { get; set; }
	[MaxLength(255)] [EmailAddress] public string? Email { get; set; }
	[MaxLength(15)] [Phone] public string? PhoneNumber { get; set; }
}