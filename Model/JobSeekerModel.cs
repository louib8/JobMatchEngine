using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobMatchEngine.Model
{
    public class JobSeekerModel
    {
        private int _id;
        private string _name;
        private List<string> _skills = new List<string>();

        public int ID { get => _id; }
        public string Name { get => _name; }
        public List<string> Skills { get => _skills; }


        public JobSeekerModel(int id, string name, List<string> skills)
        {
            _id = id;
            _name = name;
            _skills = skills;
        }
    }
}
