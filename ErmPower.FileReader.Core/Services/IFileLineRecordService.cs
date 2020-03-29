
using ErmPower.FileReader.Core.Models;
using System.Collections.Generic;

namespace ErmPower.FileReader.Core.Services
{
    public interface IFileLineRecordService
    {
        string[] GetFilesByPrefix(string folderPath);
        IEnumerable<FileLineRecord> GetFileLineRecords(string fileWithFullPath);
    }

}

