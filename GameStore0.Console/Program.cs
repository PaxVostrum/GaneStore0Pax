
using GameStore0.FileServer;
using GameStore0.FileServer.Interfaces;
using System.ComponentModel;
using System.Configuration;



await DoWork(new FileGetter(), new FileReader());

async Task DoWork(IFileGetter fileGetter, IFileReader fileReader)
{
    string path = fileGetter.GetFilePath("gamesDataPath", "gamesFileName");

    var result = await fileReader.ReadFileAsync(path);

    foreach ( var item in result )
    {
        Console.WriteLine(item);
    }

}

