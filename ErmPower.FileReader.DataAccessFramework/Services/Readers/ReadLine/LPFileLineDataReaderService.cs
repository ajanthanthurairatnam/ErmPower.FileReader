using CsvHelper;
using ErmPower.FileReader.DataAccessFramework.Models;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ErmPower.FileReader.DataAccessFramework.Services
{
    public class LPFileLineDataReaderService : ILPFileLineDataReaderService
    {
        public IEnumerable<LPFile> ReadLPFileLines(string fileWithFullPath)
        {
            using (var reader = new StreamReader(fileWithFullPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.RegisterClassMap<LPFileMap>();
                return csv.GetRecords<LPFile>().ToList();
            }
        }
    }


}
