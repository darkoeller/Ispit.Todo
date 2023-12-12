using Ispit.Todo.Data;
using Ispit.Todo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ispit.Todo.Controllers
{
	public class TaskItemsController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<AspNetUser> _userManager;

		public TaskItemsController(ApplicationDbContext context, UserManager<AspNetUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		// GET: TaskItems
		public async Task<IActionResult> Index()
		{
			var user = await _userManager.GetUserAsync(User);
			return _context.TaskItem != null
				? View(await _context.TaskItem.Where(t => t.UserId == user.Id).ToListAsync())
				: Problem("Entity set 'ApplicationDbContext.TaskItem'  is null.");
		}

		// GET: TaskItems/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.TaskItem == null)
			{
				return NotFound();
			}

			var taskItem = await _context.TaskItem
				.FirstOrDefaultAsync(m => m.Id == id);
			if (taskItem == null)
			{
				return NotFound();
			}

			return View(taskItem);
		}

		// GET: TaskItems/Create
		public IActionResult Create()
		{
			var model = new TaskItem();
			return View(model);
		}

		// POST: TaskItems/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Title,Description,IsCompleted,Created, UserId")] TaskItem taskItem)
		{
			var user = await _userManager.GetUserAsync(User);

			if (ModelState.IsValid)
			{
				// provjera je li lista nula, ako je kreira novu
				if (user.TodoList == null)
				{
					user.TodoList = new TodoList();
					_context.TodoList.Add(user.TodoList);
				}

				// dodaje zadatak listi
				user.TodoList.TaskItem.Add(taskItem);
				user.TodoList.UserId = taskItem.UserId!;
				user.TaskItem.Add(taskItem);

				//// Update korisnika
				_context.Entry(user).State = EntityState.Modified;

				// sprema promjene
				await _context.SaveChangesAsync();

				return RedirectToAction(nameof(Index));
			}

			return View(taskItem);
		}

		// GET: TaskItems/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.TaskItem == null)
			{
				return NotFound();
			}

			var taskItem = await _context.TaskItem.FindAsync(id);
			if (taskItem == null)
			{
				return NotFound();
			}

			return View(taskItem);
		}

		// POST: TaskItems/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id,
			[Bind("Id,Title,Description,IsCompleted,Created,UserId")] TaskItem taskItem)
		{
			if (id != taskItem.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(taskItem);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!TaskItemExists(taskItem.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}

				return RedirectToAction(nameof(Index));
			}

			return View(taskItem);
		}

		// GET: TaskItems/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.TaskItem == null)
			{
				return NotFound();
			}

			var taskItem = await _context.TaskItem
				.FirstOrDefaultAsync(m => m.Id == id);
			if (taskItem == null)
			{
				return NotFound();
			}

			return View(taskItem);
		}

		// POST: TaskItems/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.TaskItem == null)
			{
				return Problem("Entity set 'ApplicationDbContext.TaskItem'  is null.");
			}

			var taskItem = await _context.TaskItem.FindAsync(id);
			if (taskItem != null)
			{
				_context.TaskItem.Remove(taskItem);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool TaskItemExists(int id)
		{
			return (_context.TaskItem?.Any(e => e.Id == id)).GetValueOrDefault();
		}

		[HttpPost]
		public IActionResult UpdateTaskStatus(int id)
		{
			// dohvaća zadatak iz baze kroz Id
			var task = _context.TaskItem.Find(id);

			if (task != null)
			{
				// mijenja status
				ViewBag.TaskStatus = task.IsCompleted;
				task.IsCompleted = !task.IsCompleted;
				if (task.IsCompleted == true)
				{
					_context.Remove(task);
					_context.SaveChanges();
				}
				return Content(Url.Action("Index", "TaskItems") ?? string.Empty);
			}

			return Content(Url.Action("Index", "TaskItems") ?? string.Empty);
		}


		public IActionResult Status(int id)
		{
			var user = _userManager.GetUserId(User);
			var task = _context.TaskItem.Find(id);
			task!.IsCompleted = !task.IsCompleted;
			_context.SaveChanges();
			return RedirectToAction("Index", "TaskItems");
		}
	}
}