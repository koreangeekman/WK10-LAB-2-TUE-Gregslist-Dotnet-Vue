namespace Gregslist.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobsController(JobsService jobsService) : ControllerBase
{
  [HttpGet]
  public ActionResult<List<Job>> GetJobs()
  {
    try { return Ok(jobsService.GetJobs()); }
    catch (Exception e) { return BadRequest(e.Message); }
  }
  [HttpGet("{jobId}")]
  public ActionResult<List<Job>> GetJobById(int jobId)
  {
    try { return Ok(jobsService.GetJobById(jobId)); }
    catch (Exception e) { return BadRequest(e.Message); }
  }

  [HttpPost]
  public ActionResult<Job> CreateJob([FromBody] Job jobData)
  {
    try { return Ok(jobsService.CreateJob(jobData)); }
    catch (Exception e) { return BadRequest(e.Message); }
  }

  [HttpDelete("{jobId}")]
  public ActionResult<string> DeleteJob(int jobId)
  {
    try { return Ok(jobsService.DeleteJob(jobId)); }
    catch (Exception e) { return BadRequest(e.Message); }
  }

  [HttpPut("{jobId}")]
  public ActionResult<string> UpdateJob(int jobId, [FromBody] Job jobData)
  {
    try { return Ok(jobsService.UpdateJob(jobId, jobData)); }
    catch (Exception e) { return BadRequest(e.Message); }
  }



}