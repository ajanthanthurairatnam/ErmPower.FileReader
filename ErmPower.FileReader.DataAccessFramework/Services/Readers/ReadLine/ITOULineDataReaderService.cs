using ErmPower.FileReader.DataAccessFramework.Models;
using System.Collections.Generic;

namespace ErmPower.FileReader.DataAccessFramework.Services
{
    public interface ITOULineDataReaderService 
    {
        IEnumerable<TOUFile> ReadTOUFileLines(string fileWithFullPath);
    }


}
