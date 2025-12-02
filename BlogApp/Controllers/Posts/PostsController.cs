using BlogApp.Data.Abstract;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;

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
}