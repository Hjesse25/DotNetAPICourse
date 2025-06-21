Computer myComputer = new Computer()
{
    Motherboard = "Z690",
    HasWifi = true,
    HasLTE = false,
    ReleaseDate = DateTime.Now,
    Price = 943.87m,
    VideoCard = "RTX 2060"
};

myComputer.HasWifi = false;
Console.WriteLine(myComputer.Motherboard);
Console.WriteLine(myComputer.HasWifi);
Console.WriteLine(myComputer.VideoCard);