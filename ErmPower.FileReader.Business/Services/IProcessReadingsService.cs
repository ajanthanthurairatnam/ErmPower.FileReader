using System.Collections.Generic;

namespace ErmPower.FileReader.Business
{
    public interface IProcessReadingsService
    {
        IEnumerable<string> GetFileReadings(string folderPath);
    }
}
