﻿namespace BlogApp.Entity;

public class User
{
	public int Id { get; set; }
	
	public string? Username { get; set; }
	
	public string? Image { get; set; }
	
	public List<Post> Posts { get; set; } = new();

	public List<Comment> Comments { get; set; } = new();
}