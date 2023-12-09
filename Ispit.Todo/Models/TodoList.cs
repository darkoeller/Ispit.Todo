using System.ComponentModel.DataAnnotations;

namespace Ispit.Todo.Models;

public class TodoList
{
	[Key]
	public int Id { get; set; }

	public AspNetUser AspUser { get; set; }

	public virtual ICollection<TaskItem> TaskItem { get; set; } = new List<TaskItem>();

}

