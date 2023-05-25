using JobMatchEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobMatchEngine.Controller
{
    public static class InputController
    {

        /*
         * #TODO: Reduce the two reading methods into a single generic method to avoid unnecessary repetition.
         */

        public static List<JobSeekerModel> ReadJobSeekers(string filePath)
        {
            var jobSeekers = new List<JobSeekerModel>();

            if (!File.Exists(filePath))
            {
                // #TODO: Add a better system for handling a file that doesn't exist, should warn or alert.
                return jobSeekers;
            }

            StreamReader reader = new StreamReader(File.OpenRead(filePath));

            if (!reader.EndOfStream)
            {
                // Skip the first line which contains column names as they are not required, but only do this once.
                reader.ReadLine();
            }

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line == null) continue;
                var values = line.Split(',');

                // The following logic removes the \" characters from the first and last skill strings
                // #TODO: maybe move this to it's own method as this code is repeated elsewhere, not conforming to DRY
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
                jobSeekers.Add(new JobSeekerModel(Int32.Parse(values[0]), values[1], skills));
            }

            return jobSeekers;
        }

        public static List<JobModel> ReadJobs(string filePath)
        {
            var jobs = new List<JobModel>();

            if (!File.Exists(filePath))
            {
                // #TODO: Add a better system for handling a file that doesn't exist, should warn or alert.
                return jobs;
            }

            StreamReader reader = new StreamReader(File.OpenRead(filePath));

            if (!reader.EndOfStream)
            {
                // Skip the first line which contains column names as they are not required, but only do this once.
                reader.ReadLine();
            }

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line == null) continue;
                var values = line.Split(',');


                // The following logic removes the \" characters from the first and last skill strings
                // #TODO: maybe move this to it's own method as this code is repeated elsewhere, not conforming to DRY.
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
                jobs.Add(new JobModel(Int32.Parse(values[0]), values[1], skills));
            }

            return jobs;
        }
    }
}
