using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore0.FileServer.Interfaces
{
    public interface IFileReader
    {
        Task<IEnumerable<string>> ReadFileAsync(string path);
    }
}
