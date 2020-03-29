using ErmPower.FileReader.Core.Models;
using System.Collections.Generic;

namespace ErmPower.FileReader.Data.Services
{
    public interface IRepository
    {
        IEnumerable<FileLineRecord> FetchAll(string folderPath);
    }
}
