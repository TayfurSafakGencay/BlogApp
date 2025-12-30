namespace BlogApp.Entity;

public class Tag
{
	public int Id { get; set; }
	
	public string? Text { get; set; }
	
	public string? Url { get; set; }
	
	public List<Post> Posts { get; set; } = new();
	
	public TagColor? Color { get; set; } = TagColor.primary;
}

public enum TagColor
{
	primary,
	secondary,
	success,
	danger,
	warning,
	info,
	light,
	dark
}