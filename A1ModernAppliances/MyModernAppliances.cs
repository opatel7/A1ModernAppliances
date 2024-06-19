using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Helpers;

namespace ModernAppliances
{
    /// <summary>
    /// Manager class for Modern Appliances
    /// </summary>
    /// <remarks>Author: Omkumar Patel, Smit Patel, Karmkumar Patel</remarks>
    /// <remarks>Date: 18 June 2024</remarks>
    internal class MyModernAppliances : ModernAppliances
    {
        /// <summary>
        /// Option 1: Performs a checkout
        /// </summary>
        public override void Checkout()
        {
            Console.Write("Enter the item number of an appliance: ");
            long itemNumber;

            // Read the user input and parse it to a long
            if (!long.TryParse(Console.ReadLine(), out itemNumber))
            {
                // If parsing fails, display an error message and return
                Console.WriteLine("Invalid item number.");
                return;
            }

            // Initialize a variable to store the found appliance
            Appliance foundAppliance = null;

            // Iterate through the list of appliances to find the one with the matching item number
            foreach (var appliance in Appliances)
            {
                if (appliance.ItemNumber == itemNumber)
                {
                    // If the appliance is found, assign it to the foundAppliance variable and exit the loop
                    foundAppliance = appliance;
                    break;
                }
            }

            // Check if the appliance was found
            if (foundAppliance == null)
            {
                // If the appliance was not found, display a message indicating so
                Console.WriteLine("No appliances found with that item number.");
            }
            else
            {
                // If the appliance is found
                if (foundAppliance.IsAvailable)
                {
                    // If the appliance is available, checkout the appliance and display a success message
                    foundAppliance.Checkout();
                    Console.WriteLine($"Appliance \"{itemNumber}\" has been checked out.");
                }
                else
                {
                    // If the appliance is not available, display a message indicating so
                    Console.WriteLine("The appliance is not available to be checked out.");
                }
            }
        }

        /// <summary>
        /// Option 2: Finds appliances
        /// </summary>
        public override void Find()
        {
            // Prompt the user to enter the brand to search for
            Console.Write("Enter brand to search for: ");
            string enteredBrand = Console.ReadLine();

            // Create a list to store found appliances
            List<Appliance> found = new List<Appliance>();

            // Iterate through the list of appliances
            foreach (var appliance in Appliances)
            {
                // Check if the brand of the current appliance matches the entered brand (case-insensitive)
                if (appliance.Brand.Equals(enteredBrand, StringComparison.OrdinalIgnoreCase))
                {
                    // If a match is found, add the appliance to the list of found appliances
                    found.Add(appliance);
                }
            }

            // Check if any appliances were found
            if (found.Count > 0)
            {
                // Display a message indicating matching appliances were found
                Console.WriteLine($"Matching Appliances for Brand '{enteredBrand}':");

                // Iterate through the found appliances and display their details
                foreach (var appliance in found)
                {
                    Console.WriteLine(appliance);
                }
            }
            else
            {
                // If no appliances were found, display a message indicating so
                Console.WriteLine("No appliances found for the entered brand.");
            }
        }

        /// <summary>
        /// Displays Refridgerators
        /// </summary>
        public override void DisplayRefrigerators()
        {
            // Write "Possible options:"
            Console.WriteLine("Possible options:");

            // Write "0 - Any"
            Console.WriteLine("0 - Any");

            // Write "2 - Double doors"
            Console.WriteLine("2 - Double doors");

            // Write "3 - Three doors"
            Console.WriteLine("3 - Three doors");

            // Write "4 - Four doors"
            Console.WriteLine("4 - Four doors");

            // Write "Enter number of doors: "
            Console.Write("Enter number of doors: ");

            // Create variable to hold entered number of doors
            short numberOfDoors = 0;

            // Get user input as string and assign to variable
            string input = Console.ReadLine();

            // Convert user input from string to int and store as number of doors variable.
            if (!short.TryParse(input, out numberOfDoors) || (numberOfDoors != 0 && numberOfDoors != 2 && numberOfDoors != 3 && numberOfDoors != 4))
            {
                // Display error message for invalid input
                Console.WriteLine("Invalid option.");
                return;
            }

            // Create list to hold found Appliance objects
            List<Appliance> found = new List<Appliance>();

            // Iterate/loop through Appliances
            foreach (var appliance in Appliances)
            {
                // Test that current appliance is a refrigerator
                if (appliance is Refrigerator refrigerator)
                {
                    // Test user entered 0 or refrigerator doors equals what user entered.
                    if (numberOfDoors == 0 || refrigerator.Doors == numberOfDoors)
                    {
                        // Add current appliance in list to found list
                        found.Add(appliance);
                    }
                }
            }

            // Display found appliances
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays Vacuums
        /// </summary>
        /// <param name="grade">Grade of vacuum to find (or null for any grade)</param>
        /// <param name="voltage">Vacuum voltage (or 0 for any voltage)</param>
        public override void DisplayVacuums()
        {
            // Write "Possible options:"
            Console.WriteLine("Possible options:");

            // Write "0 - Any"
            // Write "1 - Residential"
            // Write "2 - Commercial"
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Residential");
            Console.WriteLine("2 - Commercial");

            // Write "Enter grade:"
            Console.Write("Enter grade: ");

            // Get user input as string and assign to variable
            string gradeInput = Console.ReadLine();

            // Create grade variable to hold grade to find (Any, Residential, or Commercial)
            string grade = "";

            // Test input is "0"
            if (gradeInput == "0")
            {
                // Assign "Any" to grade
                grade = "Any";
            }
            // Test input is "1"
            else if (gradeInput == "1")
            {
                // Assign "Residential" to grade
                grade = "Residential";
            }
            // Test input is "2"
            else if (gradeInput == "2")
            {
                // Assign "Commercial" to grade
                grade = "Commercial";
            }
            // Otherwise (input is something else)
            else
            {
                // Write "Invalid option."
                Console.WriteLine("Invalid option.");

                // Return to calling (previous) method
                return;
            }

            // Write "Possible options:"
            Console.WriteLine("Possible options:");

            // Write "0 - Any"
            // Write "1 - 18 Volt"
            // Write "2 - 24 Volt"
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - 18 Volt");
            Console.WriteLine("2 - 24 Volt");

            // Write "Enter voltage:"
            Console.Write("Enter voltage: ");

            // Get user input as string
            // Create variable to hold voltage
            string voltageInput = Console.ReadLine();
            short voltage = -1;

            // Test input is "0"
            if (voltageInput == "0")
            {
                // Assign 0 to voltage
                voltage = 0;
            }
            // Test input is "1"
            else if (voltageInput == "1")
            {
                // Assign 18 to voltage
                voltage = 18;
            }
            // Test input is "2"
            else if (voltageInput == "2")
            {
                // Assign 24 to voltage
                voltage = 24;
            }
            // Otherwise
            else
            {
                // Write "Invalid option."
                Console.WriteLine("Invalid option.");

                // Return to calling (previous) method
                return;
            }

            // Create found variable to hold list of found appliances.
            List<Appliance> found = new List<Appliance>();

            // Loop through Appliances
            foreach (var appliance in Appliances)
            {
                // Check if current appliance is vacuum
                if (appliance is Vacuum vacuum)
                {
                    // Test grade is "Any" or grade is equal to current vacuum grade and voltage is 0 or voltage is equal to current vacuum voltage
                    if ((grade == "Any" || vacuum.Grade == grade) && (voltage == 0 || vacuum.BatteryVoltage == voltage))
                    {
                        // Add current appliance in list to found list
                        found.Add(appliance);
                    }
                }
            }

            // Display found appliances
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays microwaves
        /// </summary>
        public override void DisplayMicrowaves()
        {
            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Kitchen");
            Console.WriteLine("2 - Work site");
            Console.Write("Enter room type: ");
            string roomTypeInput = Console.ReadLine();
            char roomType = ' ';
            switch (roomTypeInput)
            {
                case "0":
                    roomType = 'A';
                    break;
                case "1":
                    roomType = 'K';
                    break;
                case "2":
                    roomType = 'W';
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    return;
            }
            List<Appliance> found = new List<Appliance>();

            // Filter the list of appliances to include only microwaves with the specified room type
            foreach (var appliance in Appliances)
            {
                if (appliance is Microwave microwave && (roomType == 'A' || microwave.RoomType == roomType))
                {
                    found.Add(appliance);
                }
            }

            // Display the found microwaves
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays dishwashers
        /// </summary>
        public override void DisplayDishwashers()
        {
            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Quietest");
            Console.WriteLine("2 - Quieter");
            Console.WriteLine("3 - Quiet");
            Console.WriteLine("4 - Moderate");
            Console.Write("Enter sound rating: ");
            string soundRatingInput = Console.ReadLine();
            string soundRating = "";
            switch (soundRatingInput)
            {
                case "0":
                    soundRating = "Any";
                    break;
                case "1":
                    soundRating = "Qt";
                    break;
                case "2":
                    soundRating = "Qr";
                    break;
                case "3":
                    soundRating = "Qu";
                    break;
                case "4":
                    soundRating = "M";
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    return;
            }
            List<Appliance> found = new List<Appliance>();

            // Filter the list of appliances to include only dishwashers with the specified sound rating
            foreach (var appliance in Appliances)
            {
                if (appliance is Dishwasher dishwasher && (soundRating == "Any" || dishwasher.SoundRating == soundRating))
                {
                    found.Add(appliance);
                }
            }

            // Display the found dishwashers
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Generates random list of appliances
        /// </summary>
        public override void RandomList()
        {
            Console.WriteLine("Appliance Types");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 – Refrigerators");
            Console.WriteLine("2 – Vacuums");
            Console.WriteLine("3 – Microwaves");
            Console.WriteLine("4 – Dishwashers");
            Console.Write("Enter type of appliance: ");
            string applianceTypeInput = Console.ReadLine();
            Console.Write("Enter number of appliances: ");
            int num = int.Parse(Console.ReadLine());
            List<Appliance> found = new List<Appliance>();

            // Filter the list of appliances based on the specified type
            foreach (var appliance in Appliances)
            {
                switch (applianceTypeInput)
                {
                    case "0":
                        found.Add(appliance);
                        break;
                    case "1":
                        if (appliance is Refrigerator)
                            found.Add(appliance);
                        break;
                    case "2":
                        if (appliance is Vacuum)
                            found.Add(appliance);
                        break;
                    case "3":
                        if (appliance is Microwave)
                            found.Add(appliance);
                        break;
                    case "4":
                        if (appliance is Dishwasher)
                            found.Add(appliance);
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        return;
                }
            }
            found.Sort(new RandomComparer());

            // Display a randomized selection of appliances
            DisplayAppliancesFromList(found, num);
        }
    }
}
