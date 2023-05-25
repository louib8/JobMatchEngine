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

        public int JobSeekerId { get => _jobSeekerId; set => _jobSeekerId = value; }
        public string JobSeekerName { get => _jobSeekerName; set => _jobSeekerName = value; }
        public int JobId { get => _jobId; set => _jobId = value; }
        public string JobTitle { get => _jobTitle; set => _jobTitle = value; }
        public int MatchingSkillCount { get => _matchingSkillCount; set => _matchingSkillCount = value; }

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
