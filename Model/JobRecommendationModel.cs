using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobMatchEngine.Model
{
    public class JobRecommendationModel
    {
        private int _jobSeekerId;
        private string _jobSeekerName;
        private int _jobId;
        private string _jobTitle;
        private int _matchingSkillCount;

        public int JobSeekerId { get => _jobSeekerId; }
        public string JobSeekerName { get => _jobSeekerName; }
        public int JobId { get => _jobId; }
        public string JobTitle { get => _jobTitle; }
        public int MatchingSkillCount { get => _matchingSkillCount; }

        public JobRecommendationModel(int jobSeekerId, string jobSeekerName, int jobId, string jobTitle, int matchingSkillCount)
        {
            _jobSeekerId = jobSeekerId;
            _jobSeekerName = jobSeekerName;
            _jobId = jobId;
            _jobTitle = jobTitle;
            _matchingSkillCount = matchingSkillCount;
        }
    }
}
