namespace Gregslist.Models;

public class Job
{
  public int Id { get; }
  public string Title { get; set; }
  public string Description { get; set; }
  public int? Salary { get; set; }
  public DateTime CreatedAt { get; }
  public DateTime UpdatedAt { get; }
}