using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ispit.Todo.Models;

public class TaskItem
{
	[Key]
	public int Id { get; set; }

	[Required]
	[MinLength(2), MaxLength(50)]
	public string Title { get; set; } = string.Empty;

	[MinLength(2), MaxLength(250)] public string Description { get; set; } = string.Empty;

	public bool IsCompleted { get; set; }
	public DateTime Created { get; set; } = DateTime.Now;

	[ForeignKey("TodoListId")]
	public virtual TodoList TodoList { get; set; }

	public string UserId { get; set; } = string.Empty;
	public virtual AspNetUser User { get; set; }
}