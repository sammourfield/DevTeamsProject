using DevTeamsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }

        private readonly List<Developer> _developerDirectory = new List<Developer>();
        private DevTeamRepo _devTeamRepo = new DevTeamRepo();
        private DeveloperRepo _developer = new DeveloperRepo();


        public void Run()
        {
            SeedContentList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select an option from the following menu:\n" +
                    "1. Create New User\n" +
                    "2. View All Users\n" +
                    "3. Find User by Name\n" +
                    "4. Find User by ID\n" +
                    "5. Update Existing User\n" +
                    "6. Delete Existing User\n" +
                    "7. View Developer Teams\n" +
                    "8. Add Developer to Team\n" +
                    "9. View Developers In Team\n" +
                    "10. Add Developer Team\n" +
                    "11. Exit Program.");

                    

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateNewUser();
                        break;
                    case "2":
                        ViewAllUsers();
                        break;
                    case "3":
                        FindUserByName();
                        break;
                    case "4":
                        FindUserByID();
                        break;
                    case "5":
                        UpdateExistingDeveloper();
                        break;
                    case "6":
                        DeleteExistingUser();
                        break;
                    case "7":
                        ViewDevTeams();
                        break;
                    case "8":
                        AddDevToTeam();
                        break;
                    case "9":
                        ViewDevsInTeam();
                        break;
                    case "10":
                        AddDevTeam();
                        break;
                    case "11":
                        Console.WriteLine("Thanks For Using Sams Super Simple Software.");
                        keepRunning = false;
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }


        }
        private void CreateNewUser()
        {
            Console.Clear();
            Developer newDeveloper = new Developer();

            Console.WriteLine("Enter Developer Name:");
            newDeveloper.Name = Console.ReadLine();

            Console.WriteLine("Enter Developer ID:");
            string idAsString = Console.ReadLine();
            newDeveloper.DevID = int.Parse(idAsString);

            Console.WriteLine("Do you currently have PluralSight?(Y/N)");
            string pluralSight = Console.ReadLine().ToLower();

            if (pluralSight == "y")
            {
                newDeveloper.HasPluralsight = true;
            }
            else
            {
                newDeveloper.HasPluralsight = false;
            }

            _developer.AddDeveloperToList(newDeveloper);
        }
        
        private void ViewAllUsers()
        {
            Console.Clear();
            List<Developer> listOfDevelopers = _developer.GetDeveloperList();
            foreach (Developer dev in listOfDevelopers)
            {
                Console.WriteLine($"Name: {dev.Name}\n" +
                    $"Developer ID: {dev.DevID}\n" +
                    $"Currently Using Pluralsight?: {dev.HasPluralsight}\n" +
                    $"Developer Team: {dev.DevTeam}\n" +
                    $"Team ID: {dev.TeamID}") ;

            }
        }

        private void FindUserByName()
        {
            Console.Clear();
            Console.WriteLine("Enter the name of the developer you are looking for:");
            string name = Console.ReadLine();
            Developer dev = _developer.FindUserByName(name);

            if (dev != null)
            {
                Console.WriteLine($"Name: {dev.Name}\n" +
                    $"Developer ID: {dev.DevID}\n" +
                    $"Currently Using PluralSight?: {dev.HasPluralsight}");
            }
        }
        private void FindUserByID()
        {

            Console.Clear();
            Developer newDeveloper = new Developer();
            Console.WriteLine("Enter the ID of the developer you are looking for:");
            string devIdAsString = Console.ReadLine();
            newDeveloper.DevID = int.Parse(devIdAsString);
            Developer dev = _developer.GetDevByID(newDeveloper.DevID);

            if (dev != null)
            {
                Console.WriteLine($"Name: {dev.Name}\n" +
                    $"Developer ID: {dev.DevID}\n" +
                    $"Currently Using PluralSight?: {dev.HasPluralsight}");
            }
        }

        private void UpdateExistingDeveloper()
        {
            ViewAllUsers();


            Console.WriteLine("Enter the ID of the developer you'd like to update with new Information:");
            int originalID = int.Parse(Console.ReadLine());


            Developer newDeveloper = new Developer();

            Console.WriteLine("Enter the new Name for this Developer:");
            newDeveloper.Name = Console.ReadLine();

            Console.WriteLine("Enter the new ID for this Developer:");
            string devIdAsString = Console.ReadLine();
            newDeveloper.DevID = int.Parse(devIdAsString);

            Console.WriteLine("Does this Developer currently use PluralSight? (Y/N)");
            string hasPlurarlSightString = Console.ReadLine().ToLower();
            if (hasPlurarlSightString == "y")
            {
                newDeveloper.HasPluralsight = true;
            }
            else
            {
                newDeveloper.HasPluralsight = false;
            }
            Console.WriteLine("Enter the new Dev Team for this developer");
            newDeveloper.DevTeam = Console.ReadLine();

            bool wasUpdated = _developer.UpdateExisitingDev(originalID, newDeveloper);

            if (wasUpdated)
            {
                Console.WriteLine("Developer Info has been successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not complete update");
            }

        }
        private void DeleteExistingUser()
        {
            ViewAllUsers();
            Console.WriteLine("\nEnter the ID of the developer you would like to remove:");

            int input = int.Parse(Console.ReadLine());
            bool wasDeleted = _developer.RemoveDevFromList(input);

            if (wasDeleted)
            {
                Console.WriteLine("The Developer was removed from the list");
            }
            else
            {
                Console.WriteLine("The Developer could not be removed");
            }
        }

        private void ViewDevTeams()
        {
            Console.Clear();
            List<DevTeam> devTeams = _devTeamRepo.GetDevTeamList();
            foreach (DevTeam team in devTeams)
            {
                Console.WriteLine($"Team Color: {team.DevTeamColor}\n" +
                    $"Team ID: {team.DevTeamID}");
            }
        }
        private void AddDevToTeam()
        {
            ViewAllUsers();
            Console.WriteLine("Enter the ID of Developer you'd like to add to a Developer Team");
            int originalID = int.Parse(Console.ReadLine());
            DevTeam newDevTeam = new DevTeam();

            Console.WriteLine("Enter the new Dev Team for this developer");
            newDevTeam.DevTeamColor = Console.ReadLine();
        }

        private void ViewDevsInTeam()
        {
            Console.Clear();
            Console.WriteLine("Enter the Dev Team ID you'd like to view");
            int devTeamToView = int.Parse(Console.ReadLine());
            DevTeam devTeam = _devTeamRepo.GetDevTeamByID(devTeamToView);
            List<Developer> listOfDevelopers = devTeam._devTeam;
            foreach (Developer dev in listOfDevelopers)
            {

                Console.WriteLine($"Name: {dev.Name}\n" +
                    $"Developer ID: {dev.DevID}\n" +
                    $"Currently Using Pluralsight?: {dev.HasPluralsight}");
            }
            Console.ReadLine();
        }
        private void AddDevTeam()
        {
            Console.Clear();
            DevTeam newDevTeam = new DevTeam();

            Console.WriteLine("Enter Developer Team Color:");
            newDevTeam.DevTeamColor = Console.ReadLine();

            Console.WriteLine("Enter Developer Team ID:");
            string devTeamIdAsString = Console.ReadLine();
            newDevTeam.DevTeamID = int.Parse(devTeamIdAsString);
        }

        private void SeedContentList()
        {
            

            Developer jimmy = new Developer("Jimmy McNamara", 347, true, "blue", 1);
            Developer elfrid = new Developer("Elfrid Jacoby", 772, false, "red", 2);
            Developer amanda = new Developer("Amanda Bynes", 199, true, "blue", 1);
            Developer emmanual = new Developer("Emmanual Moster", 056, true, "green", 3);
            Developer samuel = new Developer("Samuel Mourfield", 998, true, "red", 2);
            Developer mary = new Developer("Mary McSnoody", 245, false, "red", 2);
            DevTeam blue = new DevTeam("blue", 1);
            DevTeam red = new DevTeam("red", 2);
            DevTeam green = new DevTeam("green", 3);

            _developer.AddDeveloperToList(jimmy);
            _developer.AddDeveloperToList(elfrid);
            _developer.AddDeveloperToList(amanda);
            _developer.AddDeveloperToList(emmanual);
            _developer.AddDeveloperToList(samuel);
            _developer.AddDeveloperToList(mary);
            _devTeamRepo.AddDeveloperTeam(blue);
            _devTeamRepo.AddDeveloperTeam(red);
            _devTeamRepo.AddDeveloperTeam(green);
            
        }







    }

}


