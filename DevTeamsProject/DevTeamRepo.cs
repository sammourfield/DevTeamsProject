using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeamRepo
    {
        
        private readonly List<DevTeam> _devTeam = new List<DevTeam>();

        public void AddDeveloperTeam(DevTeam devID)
        {
            _devTeam.Add(devID);
        }

        public List<DevTeam> GetDevTeamList()
        {
            return _devTeam;
        }

        public bool UpdateDevTeamByID(int devTeamID, DevTeam newDevTeam)
        {
            DevTeam oldDevTeam = GetDevTeamByID(devTeamID);

            if (oldDevTeam != null)
            {
                oldDevTeam.DevTeamColor = newDevTeam.DevTeamColor;
                oldDevTeam.DevTeamID = newDevTeam.DevTeamID;
                
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RemoveTeam(int devTeamID)
        {
            DevTeam devTeam = GetDevTeamByID(devTeamID);

            if (devTeam == null)
            {
                return false;
            }
            int initialCount = _devTeam.Count;
            _devTeam.Remove(devTeam);
            if(initialCount > _devTeam.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DevTeam GetDevTeamByID(int devTeamID)
        {
            foreach (DevTeam devTeam in _devTeam)
            {
                if (devTeam.DevTeamID == devTeamID)
                {
                    return devTeam;
                }
            }
            return null;
        }

        private readonly List<Developer> _developer = new List<Developer>();
        public Developer AddDevToTeam(Developer dev)
        {
            _developer.Add(dev);
            return dev;
        }




    }
}
