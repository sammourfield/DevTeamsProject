using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeam
    {
        public List<Developer> _devTeam = new List<Developer>();

        public string DevTeamColor { get; set; }
        public int DevTeamID { get; set; }

        public DevTeam() { }

        public DevTeam (string devTeamColor, int devTeamID)
        {
            DevTeamColor = devTeamColor;
            DevTeamID = devTeamID;
        }

    }
}
