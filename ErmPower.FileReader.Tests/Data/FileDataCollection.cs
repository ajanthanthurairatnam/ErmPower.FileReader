using ErmPower.FileReader.Core.Models;
using ErmPower.FileReader.DataAccessFramework.Models;
using System.Collections.Generic;
using System.Linq;

namespace ErmPower.FileReader.Tests
{
    public static class FileDataCollection
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<TOUFile> MockTOUFileInputData()
        {
            yield return new TOUFile()
            {
                MeterPointCode = "214667141",
                SerialNumber = "214667141",
                PlantCode = "ED071500133",
                ReadingDateTime = "01/09/2015 04:00:13",
                Energy = (decimal)0.004000

            };
            yield return new TOUFile()
            {
                MeterPointCode = "214667141",
                SerialNumber = "214667141",
                PlantCode = "ED071500133",
                ReadingDateTime = "01/09/2015 04:00:13",
                Energy = (decimal)0.004000

            };
            yield return new TOUFile()
            {
                MeterPointCode = "214667141",
                SerialNumber = "214667141",
                PlantCode = "ED071500133",
                ReadingDateTime = "01/09/2015 00:00:00",
                Energy = (decimal)0.146000
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<LPFile> MockLPInputData()
        {
            yield return new LPFile()
            {
                MeterPointCode = "210095893",
                SerialNumber = "210095893",
                PlantCode = "ED031000001",
                ReadingDateTime = "31/08/2015 00:45:00",
                ReadingDataValue = (decimal)0.000000

            };
            yield return new LPFile()
            {
                MeterPointCode = "210095893",
                SerialNumber = "210095893",
                PlantCode = "ED031000001",
                ReadingDateTime = "31/08/2015 01:00:00",
                ReadingDataValue = (decimal)10.000000
            };
            yield return new LPFile()
            {
                MeterPointCode = "210095893",
                SerialNumber = "210095893",
                PlantCode = "ED031000001",
                ReadingDateTime = "31/08/2015 01:15:00",
                ReadingDataValue = (decimal)0.000000
            };

        }

        public static IEnumerable<FileLineRecord> GetFileMockInputData()
        {
            var touMockData = MockTOUFileInputData().Select
                                                (e => new FileLineRecord()
                                                {
                                                    FileName = "TOU_12345.csv",
                                                    ReadingDateTime = e.ReadingDateTime,
                                                    ReadingMedianValue = 3,
                                                    ReadingValue = e.Energy
                                                });
            var lpMockData = MockLPInputData().
                                       Select(e => new FileLineRecord()
                                       {
                                           FileName = "LP_12345.csv",
                                           ReadingDateTime = e.ReadingDateTime,
                                           ReadingMedianValue = 0,
                                           ReadingValue = e.ReadingDataValue
                                       });
            return touMockData.Concat(lpMockData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<string> GetFileMockOutputData()
        {
            return new List<string>()
                                                { "TOU_12345.csv 01/09/2015 04:00:13 0.004 3",
                                                   "TOU_12345.csv 01/09/2015 04:00:13 0.004 3",
                                                   "TOU_12345.csv 01/09/2015 00:00:00 0.146 3",
                                                   "LP_12345.csv 31/08/2015 01:00:00 10 0"
                                                };

        }

        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<object[]> ProcessedReadingMockData
        {
            get
            {
                return new[]
                {
                    new object[] { GetFileMockInputData(), GetFileMockOutputData() }

                };
            }

        }




    }
}
