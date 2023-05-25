// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");




// jobseekers.csv contains jobseekers; each row represents a jobseeker and has the following columns:
//      'id': unique identifier
//      'name': name
//      'skills': comma separated list of seeker's skills

// jobs.csv contains jobs; each row is a job
//      'id': unqiue id for job
//      'title': name of job
//      'required_skills': comma separated list of skills required for the job

// read both files, for each job seeker get each matching job as per the job seekers skills matched with the jobs required skills

// output the results ordered by job seeker id, then the number of matching skills in descending order.
// if two jobs have the same number of matching skills then order by job id in ascending order

// Example output

/*
 * jobseeker_id, jobseeker_name, job_id, job_title, matching_skill_count
    1,              Alice,          5,   Ruby Developer,    3
    1,              Alice,          2,   .NET Developer,    2
    1,              Alice,          7,   C# Developer,      2
    2,              Bob,            3,   C++ Developer,     4
    2,              Bob,            1,   Go Developer,      3
 * 
 */

// Criteria:
/*
 * Correctness: Does your program correctly match jobseekers to jobs based on their skills?
 * Code quality: Is your code easy to understand and maintain?
 * Efficiency: How well does your program handle large inputs?
 */


// Code structure

/*
 * 1. read input from jobseeker.csv and create object in memory with this data (potentially hashmap with skills as the key? idk)
 * 2. read input from jobs.csv and create object in memory with this data (again, potentially hashmap, need to figure out how to correlate the two efficiently)
 * 3. run comparison by going through each jobseeker, and comparing their skills against required skills for each job
 * 4. output results
 * 
 * Take care of efficieny once a brute force solution exists, as they could scale input (big O and all that)
 * 
 * Create models for job seekers, jobs and recommendation outputs
 * intially output results to console
 * create an input reader class which it's only responsibility is to read csv files and map them to objects?
 * engine controller will handle business logic (passing correct files into csv reader class etc)
 */