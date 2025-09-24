using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore;

public static class SeedData
{
	public static void FillTestData(IApplicationBuilder applicationBuilder)
	{
		BlogContext? context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

		if (context != null)
		{
			if (context.Database.GetPendingMigrations().Any())
			{
				context.Database.Migrate();
			}
			
			AddTags(context);
			AddUsers(context);
			AddPosts(context);
		}
	}
	
	private static void AddTags(BlogContext context)
	{
		if (context.Tags.Any()) return;
		
		context.Tags.AddRange(
			new Tag { Text = "Web Programming" },
			new Tag { Text = "Backend" },
			new Tag { Text = "Frontend" },
			new Tag { Text = "Fullstack" },
			new Tag { Text = "Php" }
		);
		context.SaveChanges();
	}
	
	private static void AddUsers(BlogContext context)
	{
		if (context.Users.Any()) return;
		
		context.Users.AddRange(
			new User { Username = "Alice"},
			new User { Username = "John"},
			new User { Username = "Jane"},
			new User { Username = "Doe"}
		);
		context.SaveChanges();
	}
	
	private static void AddPosts(BlogContext context)
	{
		if (context.Posts.Any()) return;
		
		context.Posts.AddRange(
			new Post
			{
				Title = "First Post",
				Content = "This is the content of the first post.",
				PublishedOn = DateTime.Now.AddDays(-20),
				IsActive = true,
				UserId = 1,
				Tags = context.Tags.Take(3).ToList()
			},
			new Post
			{
				Title = "Second Post",
				Content = "This is the content of the second post.",
				PublishedOn = DateTime.Now.AddDays(-10),
				IsActive = true,
				UserId = 2,
				Tags = context.Tags.Skip(1).Take(2).ToList()
			},
			new Post
			{
				Title = "Third Post",
				Content = "This is the content of the third post.",
				PublishedOn = DateTime.Now.AddDays(-5),
				IsActive = false,
				UserId = 3,
				Tags = context.Tags.Skip(1).Take(3).ToList()
			}
		);
		context.SaveChanges();
	}
}