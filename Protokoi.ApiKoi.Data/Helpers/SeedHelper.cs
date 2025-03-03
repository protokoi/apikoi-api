using System.Text.Json;
using Protokoi.ApiKoi.Data.Entities;

namespace Protokoi.ApiKoi.Data.Helpers;

public static class SeedHelper
{
	public static void SeedData(this ApplicationDbContext context)
	{
		var baseFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SeedData");
		if (!context.Set<User>().Any())
		{
			var usersJson = File.ReadAllText($"{baseFileName}/user-seed.json");
			var users = JsonSerializer.Deserialize<List<User>>(usersJson);
			if (users != null)
			{
				context.Set<User>().AddRange(users);
			}
		}

		// Check and seed Categories
		if (!context.Set<Category>().Any())
		{
			var categoriesJson = File.ReadAllText($"{baseFileName}/category-seed.json");
			var categories = JsonSerializer.Deserialize<List<Category>>(categoriesJson);
			if (categories != null)
			{
				context.Set<Category>().AddRange(categories);
			}
		}

		// Check and seed Posts
		if (!context.Set<Post>().Any())
		{
			var postsJson = File.ReadAllText($"{baseFileName}/post-seed.json");
			var posts = JsonSerializer.Deserialize<List<Post>>(postsJson);
			if (posts != null)
			{
				context.Set<Post>().AddRange(posts);
			}
		}

		// Check and seed Comments
		if (!context.Set<Comment>().Any())
		{
			var commentsJson = File.ReadAllText($"{baseFileName}/comment-seed.json");
			var comments = JsonSerializer.Deserialize<List<Comment>>(commentsJson);
			if (comments != null)
			{
				context.Set<Comment>().AddRange(comments);
			}
		}

		// Check and seed Todos
		if (!context.Set<Todo>().Any())
		{
			var todosJson = File.ReadAllText($"{baseFileName}/todo-seed.json");
			var todos = JsonSerializer.Deserialize<List<Todo>>(todosJson);
			if (todos != null)
			{
				context.Set<Todo>().AddRange(todos);
			}
		}

		// Save all changes
		context.SaveChanges();
	}
}