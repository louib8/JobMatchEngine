// See https://aka.ms/new-console-template for more information

using JobMatchEngine.Controller;

var recommendationController = new RecommendationController();
recommendationController.ReadJobSeekers(@"G:\C# Dev stuff\JobMatchEngine\Data\jobseekers.csv");
recommendationController.ReadJobs(@"G:\C# Dev stuff\JobMatchEngine\Data\jobs.csv");
recommendationController.GenerateJobRecommendations();
recommendationController.SortJobRecommendations();

Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("PRITING SORTED JOB RECOMMENDATIONS");
Console.WriteLine("*****");
Console.WriteLine("jobseeker_id, jobseeker_name, job_id, job_title, matching_skill_count");
recommendationController.SortedJobRecommendations.ForEach(
    item => Console.WriteLine(
        $"{item.JobSeekerId}, {item.JobSeekerName}, {item.JobId}, {item.JobTitle}, {item.MatchingSkillCount}"
        ));

Console.ReadLine();