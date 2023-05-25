using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobMatchEngine.Model
{
    public class JobSeekerModel
    {
        private string _id;
        private string _name;
        private List<string> _skills = new List<string>();

        public string ID;
        public string Name;
        public List<string> Skills = new List<string>();


        public JobSeekerModel(string id, string name, List<string> skills)
        {
            _id = id;
            _name = name;
            _skills = skills;
        }
    }
}
