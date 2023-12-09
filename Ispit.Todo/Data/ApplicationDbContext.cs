using Ispit.Todo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ispit.Todo.Data
{
	public class ApplicationDbContext : IdentityDbContext<AspNetUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			 : base(options)
		{
		}

		public DbSet<TaskItem> TaskItem { get; set; }
		public DbSet<TodoList> TodoList { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			//builder.Entity<TaskItem>()
			//	.HasOne(t => t.User)
			//	.WithMany()
			//	.HasForeignKey(t => t.UserId);
			base.OnModelCreating(builder);
		}
	}
}
