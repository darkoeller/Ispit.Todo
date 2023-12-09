using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ispit.Todo.Models;

public class AspNetUser : IdentityUser
{
	[StringLength(50)] public string? Ime { get; set; } = string.Empty;
	[StringLength(50)] public string? Prezime { get; set; } = string.Empty;
	[StringLength(250)] public string? Adresa { get; set; } = string.Empty;
	[StringLength(50)] public string? Grad { get; set; } = string.Empty;

	[StringLength(5, ErrorMessage = "Mora biti 5 znakova.")]
	public string? PostanskiBroj { get; set; }

	[StringLength(50)] public string? Drzava { get; set; } = string.Empty;
	[ForeignKey("TodoListId")]
	public TodoList? TodoList { get; set; }

	[ForeignKey("TaskItemId")]
	public virtual ICollection<TaskItem> TaskItem { get; set; } = new List<TaskItem>();
}