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

            /*
             * #TODO: Replace below logic with something more efficient. As input for JobSeekers and Jobs grows, so to will the length of time required to process it.
             * I believe current time complexity would be O(n^2)
             */

            // Inefficent first, improve later
            foreach(var jobSeeker in JobSeekers)
            {
                foreach(var job in Jobs)
                {
                    var matchingSkillsCount = jobSeeker.Skills.Intersect(job.RequiredSkills).Count();
                    if (matchingSkillsCount <= 0)
                    {
                        continue;
                    }

                    JobRecommendations.Add(new JobRecommendationModel(
                        jobSeeker.ID,
                        jobSeeker.Name,
                        job.ID,
                        job.Title,
                        matchingSkillsCount));

                }
            }

            SortJobRecommendations();

            OutputController.PrintFormattedOutputToConsole(JobRecommendations);
        }

        public void SortJobRecommendations()
        {
            /*
             * #TODO: This is an inefficient process as we needlessly create a new list. Instead we could utilise comparators.
             */
            JobRecommendations = JobRecommendations
                .OrderBy(r => r.JobSeekerId)
                .ThenByDescending(r => r.MatchingSkillCount)
                .ThenBy(r => r.JobId)
                .ToList();
        }
    }
}