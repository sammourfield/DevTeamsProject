using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class Developer
    {
        public string Name { get; set; }
        public int DevID { get; set; }
        public bool HasPluralsight { get; set; }

        public string DevTeam { get; set; }

        public int TeamID { get; set; }
        public Developer() { }
        public Developer(string name, int devID, bool hasPluralsight, string devTeam, int teamID)
        {
            Name = name;
            DevID = devID;
            HasPluralsight = hasPluralsight;
            DevTeam = devTeam;
            TeamID = teamID;
        }

    }
}
