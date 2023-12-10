using Ispit.Todo.Models;
using System.ComponentModel.DataAnnotations;

namespace Ispit.Todo.ViewModels;

public class UpdateUserViewModel
{
	[StringLength(50, ErrorMessage = "Ne može biti duže od 50 znakova")]
	public string? Ime { get; set; } = string.Empty;
	[StringLength(50, ErrorMessage = "Ne može biti duže od 50 znakova")]
	public string? Prezime { get; set; } = string.Empty;
	[StringLength(250, ErrorMessage = "Ne može biti duže od 250 znakova")]
	public string? Adresa { get; set; } = string.Empty;
	[StringLength(50, ErrorMessage = "Ne može biti duže od 50 znakova")]
	public string? Grad { get; set; } = string.Empty;
	[StringLength(5, ErrorMessage = "Mora biti 5 znakova.")]
	public string? PostanskiBroj { get; set; }
	[StringLength(50, ErrorMessage = "Ne može biti duže od 50 znakova")]
	public string? Drzava { get; set; } = string.Empty;

	public IEnumerable<TaskItem>? TaskItems { get; set; }
}