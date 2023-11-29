namespace Gregslist.Repositories;

public class JobsRepo(IDbConnection db)
{
  internal List<Job> GetJobs()
  {
    string sql = "SELECT * FROM jobs;";
    return db.Query<Job>(sql).ToList();
  }

  internal Job GetJobById(int jobId)
  {
    string sql = "SELECT * FROM jobs WHERE id = @jobId;";
    return db.QueryFirstOrDefault<Job>(sql, new { jobId });
  }

  internal Job CreateJob(Job jobData)
  {
    string sql = @"INSERT INTO 
    jobs(title,description,salary)
    VALUES(@Title,@Description,@Salary);
    
    SELECT * FROM jobs WHERE id = LAST_INSERT_ID();";
    return db.QueryFirstOrDefault<Job>(sql, jobData);
  }

  internal void DeleteJob(int jobId)
  {
    string sql = "DELETE FROM jobs WHERE id = @jobId LIMIT 1;";
    db.Query(sql, new { jobId });
  }

  internal Job UpdateJob(Job jobData)
  {
    string sql = @"UPDATE jobs
    SET
    title = @Title,
    description = @Description,
    salary = @Salary
    WHERE id = @Id;

    SELECT * FROM jobs WHERE id = @Id;";
    return db.QueryFirstOrDefault<Job>(sql, jobData);
  }
}