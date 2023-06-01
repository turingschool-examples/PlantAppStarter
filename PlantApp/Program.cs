using PlantApp;

Room kitchen = new Room
{
    Name = "Kitchen",
    HasSunlight = true
};

Room livingroom = new Room
{
    Name = "Living Room",
    HasSunlight = true
};

Room office = new Room
{
    Name = "Office",
    HasSunlight = true
};


Plant pothos = new Plant
{
    Type = "Pothos",
    PurchaseDate = DateTime.Parse("2023-05-30").ToUniversalTime(),
    Room = kitchen
};

Plant cactus = new Plant
{
    Type = "Cactus",
    PurchaseDate = DateTime.Parse("2022-11-05").ToUniversalTime(),
    Room = livingroom
};

Plant mint = new Plant
{
    Type = "Mint",
    PurchaseDate = DateTime.Parse("2021-07-29").ToUniversalTime(),
    Room = office
};

using (var context = new PlantTrackerContext())
{
    // CREATE rooms
    context.Rooms.Add(kitchen);
    context.Rooms.Add(livingroom);
    context.Rooms.Add(office);

    // CREATE plants
    context.Plants.Add(pothos);
    context.Plants.Add(cactus);
    context.Plants.Add(mint);
    context.SaveChanges();

    // READ from database
    displayRooms(context);
    displayPlants(context);

    // UPDATE database
    var updatedRoom = context.Rooms.Single(room => room.Name == "Office");
    updatedRoom.HasSunlight = false;
    context.SaveChanges();

    var updatedPlant = context.Plants.First(plant => plant.Type == "Cactus");
    updatedPlant.Room = office;

    // READ from database
    displayRooms(context);
    displayPlants(context);

    // DELETE from database
    var deletedRoomList = context.Rooms.Where(room => room.Name == "Living Room");
    context.Rooms.RemoveRange(deletedRoomList);
    context.SaveChanges();

    // READ from database
    displayRooms(context);
    displayPlants(context);
}

void displayRooms(PlantTrackerContext context)
{
    // SELECT rooms.id, rooms.name, rooms.has_sunlight FROM rooms;
    foreach (var room in context.Rooms)
    {
        Console.WriteLine($"Room: {room.Id}, {room.Name}, {room.HasSunlight}");
    }
}

void displayPlants(PlantTrackerContext context)
{
    // SELECT plants.id, plants.type, plants.purchase_date, plants.room_id FROM plants
    foreach (var plant in context.Plants)
    {
        Console.WriteLine($"Plants: {plant.Id}, {plant.Type}," +
            $" {plant.PurchaseDate}, {plant.Room.Name}");
    }
}