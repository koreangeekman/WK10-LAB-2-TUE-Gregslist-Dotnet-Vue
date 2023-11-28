import { AppState } from "../AppState";
import { Job } from "../models/Job";
import { logger } from "../utils/Logger";
import { api } from "./AxiosService";

class JobsService {

  async getJobs() {
    const res = await api.get('api/jobs');
    const jobs = res.data.map(job => new Job(job))
    AppState.jobs = jobs
    return jobs
  }

  async getJobById(jobId) {
    const res = await api.get(`api/jobs/${jobId}`);
    return new Job(res.data)
  }

  // 🔽 AUTHENTICATION REQUIRED 🔽

  async createJob(body) {
    const res = await api.post('api/jobs', body);
    const newJob = new Job(res.data);
    AppState.jobs.unshift(newJob);
    return newJob
  }

  async removeJob(jobId, userId) {
    const toBeDeletedIndex = AppState.jobs.findIndex(h => h.id = jobId)
    if (toBeDeletedIndex == -1) { throw new logger.error('Unable to locate job with ID: ', jobId); }
    const toBeDeleted = await api.get(`api/jobs/${jobId}`)
    if (toBeDeleted.data.creatorId != userId) { throw new logger.error('Not your entry to remove'); }

    const res = await api.delete(`api/jobs/${jobId}`);

    AppState.jobs.splice(toBeDeletedIndex, 1);
    return res.data
  }

  async updateJob(jobId, newBody, userId) {
    const toBeUpdatedIndex = AppState.jobs.findIndex(h => h.id = jobId)
    if (toBeUpdatedIndex == -1) { throw new logger.error('Unable to locate job with ID: ', jobId); }
    const toBeUpdated = await api.get(`api/jobs/${jobId}`)
    if (toBeUpdated.data.creatorId != userId) { throw new logger.error('Not your entry to remove'); }

    toBeUpdated.year = newBody.year || toBeUpdated.year
    toBeUpdated.price = newBody.price || toBeUpdated.price
    toBeUpdated.imgUrl = newBody.imgUrl || toBeUpdated.imgUrl
    toBeUpdated.levels = newBody.levels || toBeUpdated.levels
    toBeUpdated.bedrooms = newBody.bedrooms || toBeUpdated.bedrooms
    toBeUpdated.bathrooms = newBody.bathrooms || toBeUpdated.bathrooms
    toBeUpdated.description = newBody.description || toBeUpdated.description

    const res = await api.put(`api/jobs/${jobId}`, toBeUpdated);

    AppState.jobs.splice(toBeUpdatedIndex, 1, new Job(res.data));
    return res.data
  }

}

export const jobsService = new JobsService();