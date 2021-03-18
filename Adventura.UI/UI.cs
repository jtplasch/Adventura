using Adventura.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Adventura.UI
{
    public class UI
    {
        private UIService _service;


        public UI(UIService service)
        {
            _service = service;
        }

        public void Run()
        {
            _service = new UIService();
        }
        public void Menu()
        {

            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("What would you like to see?\n" +
                    "1. Adventures\n" +
                    "2. Locations\n" +
                    "3. Activities\n" +
                    "4. Exit");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        GetAdventure();
                        break;
                    case "2":
                        GetLocation();
                        break;
                    case "3":
                        GetActivity();
                        break;
                  /*case "4":
                   *    CreateAdventure();
                        break;
                  case "5":
                   *    CreateLocation();
                        break;
                  case "6":
                   *    CreateActivity();
                        break;*/
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Nice try...");
                        break;
                }
            }
        }

        public void GetAdventure()
        {
            Console.Clear();
            Console.WriteLine("What is the ID of the Adventure you want to see?");
            string id = Console.ReadLine();
            Console.ReadKey(); 
            
            Console.WriteLine("Loading...");
            Thread.Sleep(50);
            Adventure adventure = _service.GetAsync<Adventure>($"https://localhost:44301/api/adventure/{id}/").Result;
            Console.Clear();

            Console.WriteLine($"\n\n{adventure.AdventureId} {adventure.Description} {adventure.Description}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            /*if (id == Adventure.AdventureId)
            {

                Console.WriteLine("Loading...");
                Thread.Sleep(50);
                Adventure adventure = _service.GetAsync<Adventure>($"https://localhost:44301/api/adventure/{id}/").Result;
                Console.Clear();

                Console.WriteLine($"\n\n{adventure.AdventureId} {adventure.Description} {adventure.Description}");
                Console.WriteLine("Press any key to continue...");
            }
            Menu();*/
        }

        public void GetLocation()
        {
            Console.Clear();
            Console.WriteLine("What is the ID of the Location you want to see?");
            string id = Console.ReadLine();

            Console.WriteLine("Loading...");
            Thread.Sleep(50);
            Location location = _service.GetAsync<Location>($"https://localhost:44301/api/location/{id}/").Result;
            Console.Clear();

            Console.WriteLine($"\n\n{location.LocationId} {location.LocationName} ");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void GetActivity()
        {
            Console.Clear();
            Console.WriteLine("What is the ID of the activity you want to see?");
            string id = Console.ReadLine();

            Console.WriteLine("Loading...");
            Thread.Sleep(50);
            Activity activity = _service.GetAsync<Activity>($"https://localhost:44301/api/activity/{id}/").Result;
            Console.Clear();

            Console.WriteLine($"\n\n{activity.ActivityId} {activity.ActivityType} {activity.ActivityDescription} {activity.ActivityLength} {activity.ActivityCost}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


    }
}