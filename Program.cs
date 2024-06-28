// See https://aka.ms/new-console-template for more information
using System.Net;

List<Plant> plants = new List<Plant>()
{
    new Plant()
    {
        Species = "Potted Plant",
        LightNeeds = 4.0,
        AskingPrice = 7.00M,
        City = "Murfreesboro",
        ZIP = 37127,
        Sold = false,

    },
     new Plant()
    {
        Species = "Mushroom Zombie Bagel Thing",
        LightNeeds = 0,
        AskingPrice = 20.00M,
        City = "Murfreesboro",
        ZIP = 37130,
        Sold = false,

    },
     new Plant()
    {
        Species = "Venusaur",
        LightNeeds = 5.0,
        AskingPrice = 99.99M,
        City = "Murfreesboro",
        ZIP = 37130,
        Sold = false,

    },
     new Plant()
    {
        Species = "A Sponge",
        LightNeeds = 1.0,
        AskingPrice = 15.00M,
        City = "Peoria",
        ZIP = 61604,
        Sold = false,

    },
     new Plant()
    {
        Species = "A Kiss From A Rose On The Grave",
        LightNeeds = 2.5,
        AskingPrice = 25.00M,
        City = "Peoria",
        ZIP = 61604,
        Sold = false,

    },
     new Plant()
    {
        Species = "Bulbasaur",
        LightNeeds = 4.0,
        AskingPrice = 59.99M,
        City = "Pallet Town",
        ZIP = 12345,
        Sold = true,

    }
};

Random random = new Random();

int randomIndex;
Plant plantOfTheDay;

do
{
    randomIndex = random.Next(0, plants.Count);
    plantOfTheDay = plants[randomIndex];
} while (plantOfTheDay.Sold);

DateTime expirationDate = DateTime.Now.AddMonths(1);

foreach (Plant plant in plants)
{
    plant.AvailableUntil =expirationDate;
}


string greeting = "Welcome to ExtraVert plant shop, where plants get a second chance at a home";
Console.WriteLine(greeting);
string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
                        0. exit
                        1. Display all plants
                        2. Post a plant to be adopted
                        3. Adopt a plant
                        4. Delist a plant
                        5. Plant of the Day
                        6. Search
                        7. View Stats");
    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Goodbye to you!");
    }
    else if (choice == "1")
    {
        Console.WriteLine("All Plants:");
        int count = 1;
       
        foreach (Plant plant in plants)
        {
            string plantDetails = PlantDetails(count, 
            plant);
            Console.WriteLine(plantDetails);
            count++;
           
        }
    }
    else if (choice == "2")
    {
        Console.WriteLine("Post the plant you plan on putting up for adoption");
        Console.Write("Species: ");
        string species = Console.ReadLine();

        Console.Write("Light Needs: ");
        double lightNeeds;
        while(!double.TryParse(Console.ReadLine(), out lightNeeds))
        {
            Console.WriteLine("Wrong Fromat.");
        }


        Console.Write("Price: ");
        decimal askingPrice;
        while(!decimal.TryParse(Console.ReadLine(), out askingPrice))
        {
            Console.WriteLine("Wrong Fromat.");
        }

        Console.Write("City: ");
        string city = Console.ReadLine();

        Console.Write("ZIP Code: ");
        int zip;
        while(!int.TryParse(Console.ReadLine(), out zip))
        {
            Console.WriteLine("Wrong Fromat.");
        }

        Console.Write("Available until when? (YYYY-MM-DD): ");
        DateTime availableUntil;
        while (!DateTime.TryParse(Console.ReadLine(), out availableUntil))
        {
            Console.WriteLine("Invlaid input. Format it right please?");
        }

        Plant newPlant = new Plant()
        {
            Species = species,
            LightNeeds = lightNeeds,
            AskingPrice = askingPrice,
            City = city,
            ZIP = zip,
            Sold = false,
            AvailableUntil = availableUntil
        };

        plants.Add(newPlant);

        Console.WriteLine("Thank you, we'll find it a home ^-^");


    }
    else if (choice == "3")
    {
        Console.WriteLine("These plants are available for adoption:");
        int count = 1;

        List<Plant> availablePlants = new List<Plant>();
        foreach (Plant plant in plants)
        {
            if (!plant.Sold && plant.AvailableUntil >= DateTime.Now)
            {
                availablePlants.Add(plant);
            }

        }
        if (availablePlants.Count == 0)
        {
            Console.WriteLine("All our plants have a home, please check back later");
        }
        else
        {
            foreach (Plant plant in availablePlants)
            {
                Console.WriteLine($"{count}. {plant.Species} in {plant.City}, would like a home for {plant.AskingPrice} dollars");
                count++;
            }
            Console.WriteLine("Which plant can you adopt? Type a number and press enter:");
            int selection;
            if (int.TryParse(Console.ReadLine(), out selection) && selection > 0 && selection <= availablePlants.Count)
            {
                availablePlants[selection - 1].Sold = true;
                Console.WriteLine("Thank you! Your plant is on their way. Please take care of it");
            }
            else
            {
                Console.WriteLine("(Austrailian accent) Thats not a plant");
            }
        }
    }
    else if (choice == "4")
    {
        Console.WriteLine("You want to delist a plant? WHY?!?");
        Console.WriteLine("Current Plants: ");

        for (int i = 0; i < plants.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City}, Price: {plants[i].AskingPrice} dollars");
           
        }
         Console.WriteLine("Which plant would you like to kick out of the house, enter a number:");
            int delistSelection;
            if (int.TryParse(Console.ReadLine(), out delistSelection) && delistSelection > 0 && delistSelection <= plants.Count)
            {
                Plant delistedPlant = plants[delistSelection - 1];
                plants.RemoveAt(delistSelection - 1);
                Console.WriteLine($"Bye '{delistedPlant.Species}' we will miss you! ;-;");
            }
            else
            {
                Console.WriteLine("Uh, we don't have that one");
            }
    }
    else if (choice == "5")
    {
        Console.WriteLine($"Congratulations to {plantOfTheDay.Species} from {plantOfTheDay.City}, for making plant of the day! It's' sunlight needs are rated a {plantOfTheDay.LightNeeds} and it would like {plantOfTheDay.AskingPrice} dollars please!");
    }
    else if (choice == "6")
    {
        FilterPlants(plants);
    }
    else if (choice == "7")
    {
        Console.WriteLine("Current Stats:");
        if (plants.Count == 0)
        {
            Console.WriteLine("There are currently no plants");
        }
        else
        {
            Plant CheapestPlant = plants[0];
            foreach (Plant plant in plants)
            {
                if (plant.AskingPrice < CheapestPlant.AskingPrice)
                {
                    CheapestPlant = plant;
                }
            }
            Console.WriteLine($"Lowest Price: {CheapestPlant.Species} for {CheapestPlant.AskingPrice} dollars is in the house");
        }
        int AvailableCount = 0;

        foreach (Plant plant in plants)
        {
            if(plant.AvailableUntil > DateTime.Now && !plant.Sold)
            {
                AvailableCount++;
            }
        }
        Console.WriteLine($"Avaliable Plants: {AvailableCount}! {AvailableCount} plants! Ah! Ah! Ah!");

        if (plants.Count == 0)
        {
            Console.WriteLine("No plants here");
        }
        else
        {
            Plant HighNeedPlants = plants[0];
            foreach (Plant plant in plants)
            {
                if(plant.LightNeeds > HighNeedPlants.LightNeeds)
                {
                    HighNeedPlants = plant;
                }
            }
            Console.WriteLine($"Highest Light Need: {HighNeedPlants.Species} needs {HighNeedPlants.LightNeeds} of light");

            if (plants.Count == 0)
            {
                Console.WriteLine("What Plants?");
            }
            else 
            {
                double TotalNeeds = 0;

                foreach(Plant plant in plants)
            {
                TotalNeeds += plant.LightNeeds;
            }
            double AverageNeeds = TotalNeeds / plants.Count;

            Console.WriteLine($"Plants Average Light Needs: {AverageNeeds:0.#}");
            }

            if (plants.Count == 0)
            {
                Console.WriteLine("Looking for some plants?");
            }
            else
            {
                int SoldCount = 0;

                foreach (Plant plant in plants)
                {
                    if (plant.Sold)
                    {
                        SoldCount++;
                    }
                }
                double Percentage = (double)SoldCount / plants.Count * 100;

                Console.WriteLine($"Adoption Percentage: {Percentage:0.##}%");
            }


        }

    }
    else
    {
        Console.WriteLine("Not an option, Please select one of the following options");
    }


}


void FilterPlants(List<Plant> plants)
{
    Console.WriteLine("Whats your light situation, on a scale between 1-5:");
    double maxLightNeeds;
    while (!double.TryParse(Console.ReadLine(), out maxLightNeeds) || maxLightNeeds < 1 || maxLightNeeds >5)
    {
        Console.WriteLine("Invalid input. Please enter a number between 1 and 5:");
    }
    List<Plant> filteredPlants = new List<Plant>();
    foreach (Plant plant in plants)
    {
        if (plant.LightNeeds <= maxLightNeeds)
        {
            filteredPlants.Add(plant);
        }
    }
    if (filteredPlants.Count == 0)
    {
        Console.WriteLine("Sorry, our plants cannot survive in your home");
    }
    else
    {
        Console.WriteLine("These plants are interested in your house:");
        int count = 1;
        foreach (Plant plant in filteredPlants)
        {
            Console.WriteLine($"{count}. {plant.Species} in {plant.City} needs {plant.LightNeeds} of light");
            count++;
        }
    }
}

string PlantDetails(int count, Plant plant)
{
   
    string PlantString = $"{count}. {plant.Species} in {plant.City} {(plant.Sold ? "was sold" : $"is available until {plant.AvailableUntil}")} for {plant.AskingPrice} dollars";
    
    return PlantString;
}
