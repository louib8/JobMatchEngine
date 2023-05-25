using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobMatchEngine.Model
{
    public class JobModel
    {
        private int _id;
        private string _title;
        private List<string> _requiredSkills = new List<string>();

        public int ID { get => _id; set => _id = value; }
        public string Title { get => _title; set => _title = value; }
        public List<string> RequiredSkills { get => _requiredSkills; set => _requiredSkills = value; }

        public JobModel(int id, string name, List<string> skills)
        {
            _id = id;
            _title = name;
            _requiredSkills = skills;
        }
    }
}
