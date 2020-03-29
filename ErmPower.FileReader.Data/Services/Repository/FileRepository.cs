using ErmPower.FileReader.Core.Models;
using ErmPower.FileReader.Core.Services;
using System.Collections.Generic;
using System.Linq;

namespace ErmPower.FileReader.Data.Services
{
    public class FileRepository : IRepository
    {
        private readonly IEnumerable<IFileLineRecordService> _fileTypeReaders;

        public FileRepository(IEnumerable<IFileLineRecordService> fileTypeReaders)
        {
            _fileTypeReaders = fileTypeReaders;
        }

        public IEnumerable<FileLineRecord> FetchAll(string folderPath)
        {
            if (_fileTypeReaders.Any())
            {
                foreach (var fileTypes in _fileTypeReaders)
                {
                    var fileNames = fileTypes.GetFilesByPrefix(folderPath);

                    foreach (var fileName in fileNames)
                    {
                        var fileLines = fileTypes.GetFileLineRecords(fileName).ToList();

                        foreach (var fileLine in fileLines)
                        {
                            yield return new FileLineRecord
                            {
                                FileName = fileName.Substring(fileName.LastIndexOf("\\") + 1),
                                ReadingDateTime = fileLine.ReadingDateTime,
                                ReadingValue = fileLine.ReadingValue,
                                ReadingMedianValue = fileLine.ReadingMedianValue

                            };
                        }
                    }

                }
            }
        }
    }
}
