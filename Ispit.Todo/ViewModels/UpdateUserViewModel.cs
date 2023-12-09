using Ispit.Todo.Models;
using System.ComponentModel.DataAnnotations;

namespace Ispit.Todo.ViewModels;

public class UpdateUserViewModel
{
	[StringLength(50)]
	public string? Ime { get; set; } = string.Empty;
	[StringLength(50)]
	public string? Prezime { get; set; } = string.Empty;
	[StringLength(250)]
	public string? Adresa { get; set; } = string.Empty;
	[StringLength(50)]
	public string? Grad { get; set; } = string.Empty;
	[StringLength(5, ErrorMessage = "Mora biti 5 znakova.")]
	public string? PostanskiBroj { get; set; }
	[StringLength(50)]
	public string? Drzava { get; set; } = string.Empty;

	public IEnumerable<TaskItem>? TaskItems { get; set; }
}