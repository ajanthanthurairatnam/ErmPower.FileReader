using ErmPower.FileReader.Core.Services;
using ErmPower.FileReader.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ErmPower.FileReader.DataAccessFramework.Services
{
    public class LPFileLineRecordService : IFileLineRecordService
    {
        private MedianService _medianService;
        private ILPFileLineDataReaderService _lPFileLineDataReaderService;

        public LPFileLineRecordService(MedianService medianService, ILPFileLineDataReaderService lPFileLineDataReaderService)
        {
            _medianService = medianService;
            _lPFileLineDataReaderService = lPFileLineDataReaderService;
        }

        /// <summary>
        /// Return the list of CSV files
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns></returns>
        public string[] GetFilesByPrefix(string folderPath)
        {
            try
            {
                return System.IO.Directory.GetFiles(folderPath, "*.csv").
                       Where(file => (file.Substring(file.LastIndexOf("\\") + 1).StartsWith("LP")))
                       .ToArray();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public IEnumerable<FileLineRecord> GetFileLineRecords(string fileWithFullPath)
        {
            var records = _lPFileLineDataReaderService.ReadLPFileLines(fileWithFullPath);
            var median = _medianService.CalculateMedian(records.Select(e => e.ReadingDataValue));
            var fileName = Path.GetFileName(fileWithFullPath);

            return records.Select(e => new FileLineRecord()
            {
                FileName = fileName,
                ReadingValue = e.ReadingDataValue,
                ReadingDateTime = e.ReadingDateTime,
                ReadingMedianValue = median
            });
        }
    }
}
