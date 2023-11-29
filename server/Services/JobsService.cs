namespace Gregslist.Services;

public class JobsService(JobsRepo jobsRepo)
{
  internal List<Job> GetJobs()
  { return jobsRepo.GetJobs(); }

  internal Job GetJobById(int jobId)
  { return jobsRepo.GetJobById(jobId); }

  internal Job CreateJob(Job jobData)
  { return jobsRepo.CreateJob(jobData); }

  internal string DeleteJob(int jobId)
  {
    jobsRepo.DeleteJob(jobId);
    return "Job was deleted";
  }
  internal Job UpdateJob(int jobId, Job jobData)
  {
    Job job = GetJobById(jobId);

    job.Title = jobData.Title ?? job.Title;
    job.Description = jobData.Description ?? job.Description;
    job.Salary = jobData.Salary ?? job.Salary;

    return jobsRepo.UpdateJob(job);
  }
}