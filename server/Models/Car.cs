namespace Gregslist.Models;

public class Car
{
  public int Id { get; }
  public string Make { get; set; }
  public string Model { get; set; }
  public string Color { get; set; }
  public string Description { get; set; }
  public int? Year { get; set; }
  public int? Price { get; set; }
  public int? Mileage { get; set; }
  public string ImgUrl { get; set; }
  public DateTime CreatedAt { get; }
  public DateTime UpdatedAt { get; }
}