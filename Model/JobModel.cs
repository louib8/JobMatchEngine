using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobMatchEngine.Model
{
    public class JobModel
    {
        private string _id;
        private string _name;
        private List<string> _skills = new List<string>();

        public string ID { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public List<string> Skills { get => _skills; set => _skills = value; }

        public JobModel(string id, string name, List<string> skills)
        {
            _id = id;
            _name = name;
            _skills = skills;
        }
    }
}
