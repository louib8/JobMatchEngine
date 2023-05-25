using JobMatchEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobMatchEngine.Controller
{
    public class RecommendationController
    {
        public List<JobSeekerModel> JobSeekers = new List<JobSeekerModel>();
        public List<JobModel> Jobs = new List<JobModel>();
        public List<JobRecommendationModel> JobRecommendations = new List<JobRecommendationModel>();
        
        public void GenerateJobRecommendations(string jobSeekerFilePath, string jobFilePath)
        {
            JobSeekers = InputController.ReadJobSeekers(jobSeekerFilePath);
            Jobs = InputController.ReadJobs(jobFilePath);

            JobRecommendations.Clear();

            // Inefficent first, improve later
            foreach(var jobSeeker in JobSeekers)
            {
                foreach(var job in Jobs)
                {
                    var matchingSkillsCount = jobSeeker.Skills.Intersect(job.RequiredSkills);
                    if (matchingSkillsCount.Count() <= 0)
                    {
                        continue;
                    }

                    JobRecommendations.Add(new JobRecommendationModel(
                        jobSeeker.ID,
                        jobSeeker.Name,
                        job.ID,
                        job.Title,
                        matchingSkillsCount.Count()));

                }
            }

            SortJobRecommendations();

            OutputController.PrintFormattedOutputToConsole(JobRecommendations);
        }

        public void SortJobRecommendations()
        {
            JobRecommendations = JobRecommendations
                .OrderBy(r => r.JobSeekerId)
                .ThenByDescending(r => r.MatchingSkillCount)
                .ThenBy(r => r.JobId)
                .ToList();
        }
    }
}