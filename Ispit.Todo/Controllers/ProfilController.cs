using Ispit.Todo.Data;
using Ispit.Todo.Models;
using Ispit.Todo.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ispit.Todo.Controllers
{
	[Authorize]
	public class ProfilController : Controller
	{
		private readonly UserManager<AspNetUser> _userManager;
		//private readonly SignInManager<AspNetUser> _signInManager;
		private readonly ApplicationDbContext _context;

		public ProfilController(UserManager<AspNetUser> userManager, ApplicationDbContext context)
		{
			_userManager = userManager;
			//_signInManager = signInManager;
			_context = context;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{

			var model = new UpdateUserViewModel();
			var user = await _userManager.GetUserAsync(User);
			var tasks = await _context.TaskItem.Where(t => t.UserId == user.Id).ToListAsync();

			model.Ime = user.Ime;
			model.Prezime = user.Prezime;
			model.Adresa = user.Adresa;
			model.Grad = user.Grad;
			model.PostanskiBroj = user.PostanskiBroj;
			model.Drzava = user.Drzava;
			model.TaskItems = user.TaskItem.ToList();
			model.TaskItems = tasks;
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> UpdateData(UpdateUserViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.GetUserAsync(User);
				user.Ime = model.Ime;
				user.Prezime = model.Prezime;
				user.Adresa = model.Adresa;
				user.Grad = model.Grad;
				user.PostanskiBroj = model.PostanskiBroj;
				user.Drzava = model.Drzava;
				var result = await _userManager.UpdateAsync(user);
				if (result.Succeeded)
				{
					return View("UpgradeData");
				}
			}
			return View("Error");
		}
	}
}