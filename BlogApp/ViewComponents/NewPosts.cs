using BlogApp.Data.Abstract;
using BlogApp.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.ViewComponents;

public class NewPosts : ViewComponent
{
	private IPostRepository _postRepository;

	public NewPosts(IPostRepository postRepository)
	{
		_postRepository = postRepository;
	}

	public IViewComponentResult Invoke()
	{
		List<Post> posts = _postRepository.Posts.OrderByDescending(p => p.PublishedOn).Take(5).ToList();
		
		return View(posts);
	}
}