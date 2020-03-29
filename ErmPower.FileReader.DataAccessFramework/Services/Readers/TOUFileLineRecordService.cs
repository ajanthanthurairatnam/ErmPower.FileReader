using ErmPower.FileReader.Core.Models;
using ErmPower.FileReader.Core.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ErmPower.FileReader.DataAccessFramework.Services
{
    public class TOUFileLineRecordService : IFileLineRecordService
    {

        private MedianService _medianService;
        private ITOULineDataReaderService _tOULineDataReaderService;

        public TOUFileLineRecordService(MedianService medianService, ITOULineDataReaderService tOULineDataReaderService)
        {
            _medianService = medianService;
            _tOULineDataReaderService = tOULineDataReaderService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns></returns>
        public string[] GetFilesByPrefix(string folderPath)
        {
            try
            {
                return System.IO.Directory.GetFiles(folderPath, "*.csv").
                       Where(file => (file.Substring(file.LastIndexOf("\\") + 1)).StartsWith("TOU"))
                       .ToArray();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileWithFullPath"></param>
        /// <returns></returns>
        public IEnumerable<FileLineRecord> GetFileLineRecords(string fileWithFullPath)
        {

            var records = _tOULineDataReaderService.ReadTOUFileLines(fileWithFullPath);
            var median = _medianService.CalculateMedian(records.Select(e => e.Energy));
            var fileName = Path.GetFileName(fileWithFullPath);
            return records.Select(e => new FileLineRecord()
            {
                FileName = fileName,
                ReadingValue = e.Energy,
                ReadingDateTime = e.ReadingDateTime,
                ReadingMedianValue = median
            });

        }

  
    }
}
