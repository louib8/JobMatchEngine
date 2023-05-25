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

        public int ID { get => _id; }
        public string Title { get => _title; }
        public List<string> RequiredSkills { get => _requiredSkills; }

        public JobModel(int id, string name, List<string> requiredSkills)
        {
            _id = id;
            _title = name;
            _requiredSkills = requiredSkills;
        }
    }
}
