// See https://aka.ms/new-console-template for more information

using JobMatchEngine.Controller;

var jobSeekerFileName = @"Data\jobseekers.csv";
var jobsFileName = @"Data\jobs.csv";

var jobSeekerFilePath = Path.Combine(Environment.CurrentDirectory, jobSeekerFileName);
var jobsFilePath = Path.Combine(Environment.CurrentDirectory, jobsFileName);
var recommendationController = new RecommendationController();
recommendationController.GenerateJobRecommendations(jobSeekerFilePath, jobsFilePath);

// To review output data without console closing.
Console.ReadLine();