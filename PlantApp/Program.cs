using PlantApp;

Console.WriteLine("Welcome to Plant Tracker!");
Console.WriteLine();

// Ask users to create rooms and plants
using (var context = new PlantTrackerContext())
{
    //Create 2 rooms
    for (var i = 0; i < 2; i++)
    {
        // Get room information
        Console.Write("Enter the name of a room: ");
        string nameInput = Console.ReadLine();
        Console.Write($"Does the {nameInput} have sunlight? Y / N : ");
        string sunlightInput = Console.ReadLine().ToLower();
        bool hasSunlight = false;
        if (sunlightInput == "y")
        {
            hasSunlight = true;
        }

        // Create Room
        Room newRoom = new Room() { Name = nameInput, HasSunlight = hasSunlight };
        context.Rooms.Add(newRoom);
        Console.WriteLine();
    }
    context.SaveChanges();

    // Add plants to each room
    foreach (var room in context.Rooms)
    {
        Console.Write($"How many plants are in the {room.Name}? ");
        Console.WriteLine();
        int numPlants = Convert.ToInt32(Console.ReadLine());

        for (var i = 1; i <= numPlants; i++)
        {
            Console.WriteLine($"Enter the information for plant #{i}");
            Console.Write("Type: ");
            string typeInput = Console.ReadLine();
            Console.Write("Date Purchased (mm/dd/yyyy): ");
            DateTime dateInput = DateTime.Parse(Console.ReadLine()).ToUniversalTime();
            Plant newPlant = new Plant() { Type = typeInput, PurchaseDate = dateInput, Room = room };
            context.Plants.Add(newPlant);
            Console.WriteLine();
        }
    }
    context.SaveChanges();
}

// display information about rooms and plants
using (var context = new PlantTrackerContext())
{

}

// If you want to remove all plant and room records, uncomment the following:
//using (var context = new PlantTrackerContext())
//{
//    context.Plants.RemoveRange(context.Plants);
//    context.Rooms.RemoveRange(context.Rooms);
//    context.SaveChanges();
//}