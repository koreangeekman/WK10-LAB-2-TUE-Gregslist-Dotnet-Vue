namespace Gregslist.Models;

public class House
{
  public int Id { get; }
  public string Title { get; set; }
  public string Description { get; set; }
  public int? Year { get; set; }
  public int? Price { get; set; }
  public int? Bedrooms { get; set; }
  public int? Bathrooms { get; set; }
  public string ImgUrl { get; set; }
  public DateTime CreatedAt { get; }
  public DateTime UpdatedAt { get; }
}