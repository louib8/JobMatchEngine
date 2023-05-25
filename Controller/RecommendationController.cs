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
        public List<JobRecommendationModel> SortedJobRecommendations = new List<JobRecommendationModel>();
        
        public void SortJobRecommendations()
        {
            SortedJobRecommendations = JobRecommendations
                .OrderBy(r => r.JobSeekerId)
                .ThenByDescending(r => r.MatchingSkillCount)
                .ThenBy(r => r.JobId)
                .ToList();
        }

        public List<JobRecommendationModel> GenerateJobRecommendations()
        {
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
            
            return JobRecommendations;
        }

        public List<JobSeekerModel> ReadJobSeekers(string filePath)
        {
            JobSeekers.Clear();

            if (!File.Exists(filePath))
            {
                return JobSeekers;
            }

            StreamReader reader = new StreamReader(File.OpenRead(filePath));

            if (!reader.EndOfStream)
            {
                // Skip the first line which contains column names as they are not required.
                reader.ReadLine();
            }

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line == null) continue;
                var values = line.Split(',');


                // To remove the \" characters from the string - maybe move this to it's own method.
                var firstSkillIndex = 2;
                var lastSkillIndex = values.Length - 1;
                values[firstSkillIndex] = values[firstSkillIndex].Remove(0, 1);
                values[lastSkillIndex] = values[lastSkillIndex].Remove(values[lastSkillIndex].Length - 1, 1);

                var skills = new List<string>();

                for (int i = 2; i < values.Length; i++)
                {
                    skills.Add(values[i]);
                }

                JobSeekers.Add(new JobSeekerModel(Int32.Parse(values[0]), values[1], skills));
            }

            return JobSeekers;
        }

        public List<JobModel> ReadJobs(string filePath)
        {
            Jobs.Clear();

            if (!File.Exists(filePath))
            {
                return Jobs;
            }

            StreamReader reader = new StreamReader(File.OpenRead(filePath));

            if (!reader.EndOfStream)
            {
                // Skip the first line which contains column names as they are not required.
                reader.ReadLine();
            }

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line == null) continue;
                var values = line.Split(',');


                // To remove the \" characters from the string - maybe move this to it's own method.
                var firstSkillIndex = 2;
                var lastSkillIndex = values.Length - 1;
                values[firstSkillIndex] = values[firstSkillIndex].Remove(0, 1);
                values[lastSkillIndex] = values[lastSkillIndex].Remove(values[lastSkillIndex].Length - 1, 1);

                var skills = new List<string>();

                for (int i = 2; i < values.Length; i++)
                {
                    skills.Add(values[i]);
                }

                // #TODO: This parsing needs to be done in a safer way, will come back
                Jobs.Add(new JobModel(Int32.Parse(values[0]), values[1], skills));
            }

            return Jobs;
        }
    }
}
