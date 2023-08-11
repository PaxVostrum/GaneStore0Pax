using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore0.Client.TempServ;

public class TempFileGetter
{
    public static string GetTempDataFile()
    {
        if (!File.Exists(Path.Combine("TempServ", "gamesData.csv")))
        {
            throw new IOException();
        }
        return Path.Combine("TempServ","gamesData.csv");//Path.Combine( "C:\Proj\GaneStore0\GameStore0.Client\TempServ\gamesData.csv";
    }
}