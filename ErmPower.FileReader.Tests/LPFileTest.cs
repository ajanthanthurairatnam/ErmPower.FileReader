using ErmPower.FileReader.Core.Services;
using ErmPower.FileReader.DataAccessFramework.Services;
using Moq;
using System.Linq;
using Xunit;

namespace ErmPower.FileReader.Tests
{
    public class LPFileTest
    {
        /// <summary>
        /// Test records exists
        /// Test record count
        /// Test median
        [Fact]
        public void LP_FileRecords_Test()
        {
            var mockDataReaderService = new Mock<ILPFileLineDataReaderService>() { CallBase = true };
            mockDataReaderService.Setup(x => x.ReadLPFileLines(""))
            .Returns(FileDataCollection.MockLPInputData());

            var lineReaderService = new LPFileLineRecordService(new MedianService(), mockDataReaderService.Object);
            var fileRecords = lineReaderService.GetFileLineRecords("");

            Assert.True(fileRecords != null);
            Assert.True(fileRecords.Count() == 3);
            Assert.Equal(0, fileRecords.FirstOrDefault().ReadingMedianValue);

        }
    }


}
