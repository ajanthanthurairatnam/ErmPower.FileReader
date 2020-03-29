using CsvHelper;
using ErmPower.FileReader.DataAccessFramework.Models;
using ErmPower.FileReader.DataAccessFramework.Services;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ErmPower.FileReader.Data.Services
{
    public class TOULineDataReaderService : ITOULineDataReaderService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileWithFullPath"></param>
        /// <returns></returns>
        public IEnumerable<TOUFile> ReadTOUFileLines(string fileWithFullPath)
        {
            using (var reader = new StreamReader(fileWithFullPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.RegisterClassMap<TOUFileMap>();
                return csv.GetRecords<TOUFile>().ToList();
            }
        }
    }


}
