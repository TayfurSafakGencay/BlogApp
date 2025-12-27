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
			new Tag { Text = "Web Programming", Url = "web-programming" },
			new Tag { Text = "Backend", Url = "backend" },
			new Tag { Text = "Frontend", Url = "frontend" },
			new Tag { Text = "Fullstack", Url = "fullstack" },
			new Tag { Text = "Php", Url = "php" }
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
				Title = "Asp.Net Core",
				Content = "Asp.Net Core is a cross-platform, high-performance framework for building modern, cloud-based, Internet-connected applications.",
				Url = "aspnet-core",
				PublishedOn = DateTime.Now.AddDays(-20),
				IsActive = true,
				UserId = 1,
				Image = "1.jpg",
				Tags = context.Tags.Take(3).ToList()
			},
			new Post
			{
				Title = "PHP Basics",
				Content = "PHP is a popular general-purpose scripting language that is especially suited to web development.",
				Url = "php",
				PublishedOn = DateTime.Now.AddDays(-10),
				IsActive = true,
				UserId = 2,
				Image = "2.jpg",
				Tags = context.Tags.Skip(1).Take(2).ToList()
			},
			new Post
			{
				Title = "Django Framework",
				Content = "Django is a high-level Python web framework that encourages rapid development and clean, pragmatic design.",
				Url = "django",
				PublishedOn = DateTime.Now.AddDays(-5),
				IsActive = false,
				UserId = 3,
				Image = "3.jpg",
				Tags = context.Tags.Skip(1).Take(3).ToList()
			},
			new Post
			{
				Title = "React",
				Content = "React is a JavaScript library for building user interfaces.",
				Url = "react-courses",
				PublishedOn = DateTime.Now.AddDays(-35),
				IsActive = false,
				UserId = 3,
				Image = "3.jpg",
				Tags = context.Tags.Skip(1).Take(3).ToList()
			},
			new Post
			{
				Title = "Angular",
				Content = "Angular is a platform for building mobile and desktop web applications.",
				Url = "angular",
				PublishedOn = DateTime.Now.AddDays(-43),
				IsActive = false,
				UserId = 3,
				Image = "3.jpg",
				Tags = context.Tags.Skip(1).Take(3).ToList()
			},
			new Post
			{
				Title = "Vue.js",
				Content = "Vue.js is a progressive framework for building user interfaces.",
				Url = "vuejs",
				PublishedOn = DateTime.Now.AddDays(-17),
				IsActive = false,
				UserId = 3,
				Image = "3.jpg",
				Tags = context.Tags.Skip(1).Take(3).ToList()
			}
		);
		context.SaveChanges();
	}
}