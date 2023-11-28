namespace Gregslist.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarController(CarService carService) : ControllerBase
{
  [HttpGet]
  public ActionResult<List<Car>> GetCars()
  {
    try { return Ok(carService.GetCars()); }
    catch (Exception e) { return BadRequest(e.Message); }
  }

  [HttpGet("{carId}")]
  public ActionResult<Car> GetCarById(int carId)
  {
    try { return Ok(carService.GetCarById(carId)); }
    catch (Exception e) { return BadRequest(e.Message); }
  }

  [HttpPost]
  public ActionResult<Car> CreateCar([FromBody] Car carData)
  {
    try { return Ok(carService.CreateCar(carData)); }
    catch (Exception e) { return BadRequest(e.Message); }
  }

  [HttpPut("{carId}")]
  public ActionResult<Car> UpdateCar(int carId, [FromBody] Car carData)
  {
    try { return Ok(carService.UpdateCar(carId, carData)); }
    catch (Exception e) { return BadRequest(e.Message); }
  }

}