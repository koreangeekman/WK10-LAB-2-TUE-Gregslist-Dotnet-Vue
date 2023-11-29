namespace Gregslist.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HousesController(HousesService housesService) : ControllerBase
{
  [HttpGet]
  public ActionResult<List<House>> GetHouses()
  {
    try { return Ok(housesService.GetHouses()); }
    catch (Exception e) { return BadRequest(e.Message); }
  }

  [HttpGet("{houseId}")]
  public ActionResult<House> GetHouseById(int houseId)
  {
    try { return Ok(housesService.GetHouseById(houseId)); }
    catch (Exception e) { return BadRequest(e.Message); }
  }

  [HttpPost]
  public ActionResult<House> CreateHouse([FromBody] House houseData)
  {
    try { return Ok(housesService.CreateHouse(houseData)); }
    catch (Exception e) { return BadRequest(e.Message); }
  }

  [HttpDelete("{houseId}")]
  public ActionResult<string> DeleteHouse(int houseId)
  {
    try { return Ok(housesService.DeleteHouse(houseId)); }
    catch (Exception e) { return BadRequest(e.Message); }
  }

  [HttpPut("{houseId}")]
  public ActionResult<House> UpdateHouse(int houseId, [FromBody] House houseData)
  {
    try { return Ok(housesService.UpdateHouse(houseId, houseData)); }
    catch (Exception e) { return BadRequest(e.Message); }
  }

}