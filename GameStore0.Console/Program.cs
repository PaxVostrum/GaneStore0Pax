using GameStore0.FileServer;
using GameStore0.FileServer.Interfaces;

var fileGetter = new FileGetter();


await DoWork(new FileReader());

async Task DoWork(IFileReader fileReader)
{
    // var path = fileGetter.GetFilePath("gamesDataPath", "gamesFileName");

    // var result = await fileReader.ReadFileAsync(path);
	
	var result = new string[]{"one","two","three"};
	
    foreach (var item in result)
    {
        Console.WriteLine(item);
    }
}

