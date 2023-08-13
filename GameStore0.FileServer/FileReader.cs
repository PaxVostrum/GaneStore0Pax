using GameStore0.FileServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore0.FileServer
{
    public class FileReader : IFileReader
    {
        public async Task<IEnumerable<string>> ReadFileAsync(string path)
        {
            if (!File.Exists(path))
            {
                throw new IOException($"File {path} doesn't exist");
            }
            using StreamReader sr = new StreamReader(path);
            var resultList = new List<string>();
            while (!sr.EndOfStream)
            {
                string line = await sr.ReadLineAsync();
                if (string.IsNullOrWhiteSpace(line))
                    continue;
                resultList.Add(line);
            }

            return resultList;
        }
    }
}
