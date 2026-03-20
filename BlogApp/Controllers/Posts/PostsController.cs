using System.Diagnostics;
using BlogApp.Data.Abstract;
using BlogApp.Entity;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Controllers.Posts;

public class PostsController : Controller
{
	private IPostRepository _postRepository;
	
	private ITagRepository _tagRepository;
	
	public PostsController (IPostRepository postRepository, ITagRepository tagRepository)
	{
		_postRepository = postRepository;
		_tagRepository = tagRepository;
	}
	
	public async Task<IActionResult> Index(string tag)
	{
		IQueryable<Post> posts = _postRepository.Posts;

		if (!string.IsNullOrEmpty(tag))
		{
			posts = posts.Where(x => x.Tags.Any(t => t.Url == tag));
		}
		
		PostsViewModel viewModel = new()
		{
			Posts = await posts.ToListAsync()
		};
		
		return View(viewModel);
	}

	public async Task<IActionResult> Details(string? url)
	{
		return View(await _postRepository
			.Posts
			.Include(x => x.Tags)
			.Include(c => c.Comments)
			.ThenInclude(u => u.User)
			.FirstOrDefaultAsync(p => p.Url == url));
	}

	public IActionResult AddComment(int postId, string UserName, string Text)
	{
		Debug.Print($"AddComment {postId} {UserName} {Text}");
		return View(null);
	}
}