using JobMatchEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobMatchEngine.Controller
{
    public static class OutputController
    {
        public static void PrintFormattedOutputToConsole(List<JobRecommendationModel> jobRecommendations)
        {
            Console.WriteLine("PRINTING SORTED JOB RECOMMENDATIONS");
            Console.WriteLine("*****");
            Console.WriteLine("jobseeker_id, jobseeker_name, job_id, job_title, matching_skill_count");
            jobRecommendations.ForEach(
                item => Console.WriteLine(
                    $"{item.JobSeekerId}, {item.JobSeekerName}, {item.JobId}, {item.JobTitle}, {item.MatchingSkillCount}"
                    ));
        }
    }
}
