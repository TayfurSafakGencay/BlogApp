using BlogApp.Data.Abstract;
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
	
	public IActionResult Index()
	{
		PostsViewModel viewModel = new()
		{
			Posts = _postRepository.Posts.ToList(),
			Tags = _tagRepository.Tags.ToList()
		};
		
		return View(viewModel);
	}

	public async Task<IActionResult> Details(string? url)
	{
		return View(await _postRepository.Posts.FirstOrDefaultAsync(p => p.Url == url));
	}
}