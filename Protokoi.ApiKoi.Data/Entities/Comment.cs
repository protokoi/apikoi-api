using System.ComponentModel.DataAnnotations;
using Protokoi.ApiKoi.Core.Shared.Models;
using Protokoi.ApiKoi.Data.Enumerations;

namespace Protokoi.ApiKoi.Data.Entities;

public sealed class Comment : AuditedEntity
{
	[MaxLength(4096)]
	public string? Content { get; set; }
	public long? PostId { get; set; }
	public long? ParentCommentId { get; set; }
	private List<Comment>? _comments { get; set; }
	public CommentTypes CommentType { get; set; }
	public ICollection<Comment>? Comments => _comments;
	public void AddComment(Comment comment)
	{
		_comments ??= new List<Comment>();

		_comments.Add(comment);
	}
}