using Intermediate.Data;
using Intermediate.Models;

DataContextDapper dapper = new DataContextDapper();

DateTime rightNow = dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");

// Console.WriteLine(rightNow.ToString());

Computer myComputer = new Computer()
{
    Motherboard = "Z690",
    HasWifi = true,
    HasLTE = false,
    ReleaseDate = DateTime.Now,
    Price = 943.87m,
    VideoCard = "RTX 2060"
};

string sql = @"INSERT INTO TutorialAppSchema.Computer (
    Motherboard,
    HasWifi,
    HasLTE,
    ReleaseDate,
    Price,
    VideoCard
) VALUES ('" + myComputer.Motherboard
        + "','" + myComputer.HasWifi
        + "','" + myComputer.HasLTE
        + "','" + myComputer.ReleaseDate.ToString("MM-dd-yyyy")
        + "','" + myComputer.Price
        + "','" + myComputer.VideoCard
+ "')";

// Console.WriteLine(sql);

// int result = dapper.ExecuteSqlWithRowCount(sql);
bool result = dapper.ExecuteSql(sql);

// Console.WriteLine(result);

string sqlSelect = @"SELECT 
    Computer.Motherboard,
    Computer.HasWifi,
    Computer.HasLTE,
    Computer.ReleaseDate,
    Computer.Price,
    Computer.VideoCard
FROM TutorialAppSchema.Computer";

IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlSelect);

Console.WriteLine("'Motherboard', 'HasWifi', 'HasLTE', 'ReleaseDate'"
    + "'Price', 'VideoCard'");
foreach (Computer singleComputer in computers)
{
    Console.WriteLine(myComputer.Motherboard
        + "','" + myComputer.HasWifi
        + "','" + myComputer.HasLTE
        + "','" + myComputer.ReleaseDate.ToString("MM-dd-yyyy")
        + "','" + myComputer.Price
        + "','" + myComputer.VideoCard
+ "'");
}

// myComputer.HasWifi = false;
// Console.WriteLine(myComputer.Motherboard);
// Console.WriteLine(myComputer.HasWifi);
// Console.WriteLine(myComputer.VideoCard);