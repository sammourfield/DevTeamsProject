using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DeveloperRepo
    {

        private readonly List<Developer> _developerDirectory = new List<Developer>();


        //DevTeam Create
        public void AddDeveloperToList(Developer dev)
        {
            _developerDirectory.Add(dev);
        }
        //DevTeam Read
        public List<Developer> GetDeveloperList()
        {
            return _developerDirectory;
        }
        //DevTeam Update
        public bool UpdateExisitingDev(int originalDevID, Developer newDev)
        {
            Developer oldDev = GetDevByID(originalDevID);

            if (oldDev != null)
            {
                oldDev.Name = newDev.Name;
                oldDev.DevID = newDev.DevID;
                oldDev.HasPluralsight = newDev.HasPluralsight;
                return true;
            }
            else
            {
                return false;
            }
        }


        //DevTeam Delete
        public bool RemoveDevFromList(int devID)
        {
            Developer dev = GetDevByID(devID);
            if (dev == null)
            {
                return false;
            }
            int initialCount = _developerDirectory.Count;
            _developerDirectory.Remove(dev);

            if (initialCount > _developerDirectory.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //DevTeam Helper (Get Team by ID)
        public Developer GetDevByID(int devID)
        {
            foreach (Developer dev in _developerDirectory)
            {
                if (dev.DevID == devID)
                {
                    return dev;
                }
            }
            return null;
        }
        public Developer FindUserByName(string title)
        {

            foreach (Developer dev in _developerDirectory)
            {
                if (dev.Name.ToLower() == title.ToLower())
                {
                    return dev;
                }
            }

            return null;
        }
    }
}
