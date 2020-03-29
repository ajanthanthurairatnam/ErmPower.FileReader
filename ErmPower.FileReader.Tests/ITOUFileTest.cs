using ErmPower.FileReader.Core.Services;
using ErmPower.FileReader.Data.Services;
using ErmPower.FileReader.DataAccessFramework.Services;
using Moq;
using System.Linq;
using Xunit;

namespace ErmPower.FileReader.Tests
{
    public class TOUFileTest
    {

        /// <summary>
        /// Test records exists
        /// Test record count
        /// Test median
        /// </summary>
        [Fact]
        public void TOU_FileRecords_Test()
        {
            var mockDataReaderService = new Mock<ITOULineDataReaderService>() { CallBase = true };
                mockDataReaderService.Setup(x => x.ReadTOUFileLines(""))
                .Returns(FileDataCollection.MockTOUFileInputData());

            var lineReaderService = new TOUFileLineRecordService(new MedianService(), mockDataReaderService.Object);
            var fileRecords = lineReaderService.GetFileLineRecords("");

            Assert.True(fileRecords != null);
            Assert.True(fileRecords.Count() == 3);
            Assert.Equal((decimal)0.004000, fileRecords.FirstOrDefault().ReadingMedianValue);

            
        }
    }


}
