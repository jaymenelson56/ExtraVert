// See https://aka.ms/new-console-template for more information
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

    }
};

string greeting = "Welcome to ExtraVert plant shop, where plants get a second chance at a home";
Console.WriteLine(greeting);
string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
                        0. exit
                        a. Display all plants
                        b. Post a plant to be adopted
                        c. Adopt a plant
                        d. Delist a plant");
    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Later");
    }
    else if (choice == "a")
    {
            throw new NotImplementedException("Display all plants");
    }
    else if (choice == "b")
    {
        throw new NotImplementedException("Post a plant to be adopted");
    }
    else if (choice == "c")
    {
        throw new NotImplementedException("Adopt a plant");
    }
    else if (choice == "d")
    {
        throw new NotImplementedException("delist a plant");
    }
    else
    {
        Console.WriteLine("Not an option, Please select one of the following options");
    }
}


// for (int i = 0; i < plants.Count; i++)
// {
//     Console.WriteLine($"{i + 1}. {plants[i].Species}");
// }