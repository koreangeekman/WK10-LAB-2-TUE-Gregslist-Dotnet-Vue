namespace Gregslist.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController(CarsService carsService) : ControllerBase
{
  [HttpGet]
  public ActionResult<List<Car>> GetCars()
  {
    try { return Ok(carsService.GetCars()); }
    catch (Exception e) { return BadRequest(e.Message); }
  }

  [HttpGet("{carId}")]
  public ActionResult<Car> GetCarById(int carId)
  {
    try { return Ok(carsService.GetCarById(carId)); }
    catch (Exception e) { return BadRequest(e.Message); }
  }

  [HttpPost]
  public ActionResult<Car> CreateCar([FromBody] Car carData)
  {
    try { return Ok(carsService.CreateCar(carData)); }
    catch (Exception e) { return BadRequest(e.Message); }
  }

  [HttpPut("{carId}")]
  public ActionResult<Car> UpdateCar(int carId, [FromBody] Car carData)
  {
    try { return Ok(carsService.UpdateCar(carId, carData)); }
    catch (Exception e) { return BadRequest(e.Message); }
  }

}