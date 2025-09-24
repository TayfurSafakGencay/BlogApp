using BlogApp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers.Posts;

public class PostsController : Controller
{
	private IPostRepository _postRepository;
	
	public PostsController (IPostRepository postRepository)
	{
		_postRepository = postRepository;
	}
	
	public IActionResult Index()
	{
		return View(_postRepository.Posts.ToList());
	}
}