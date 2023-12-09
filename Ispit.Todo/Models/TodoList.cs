using System.ComponentModel.DataAnnotations;

namespace Ispit.Todo.Models;

public class TodoList
{
	[Key]
	public int Id { get; set; }
	public string UserId { get; set; }

	//[ForeignKey("UserId")]
	public AspNetUser AspUser { get; set; }

	public virtual ICollection<TaskItem> TaskItem { get; set; } = new List<TaskItem>();

}

