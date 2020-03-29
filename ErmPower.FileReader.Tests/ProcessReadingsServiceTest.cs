using ErmPower.FileReader.Business.Services;
using ErmPower.FileReader.Core.Models;
using ErmPower.FileReader.Data.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ErmPower.FileReader.Tests
{
    public class ProcessReadingsServiceTest
    {
        /// <summary>
        /// Test processed data        
        [Fact]
        public void ProcessReadingsService_Test()
        {
            //Arrange
            var mockDataRepository = new Mock<IRepository>() { CallBase = true };
            mockDataRepository.Setup(x => x.FetchAll(""))
            .Returns(FileDataCollection.GetFileMockInputData());

            //ACT SUT ProcessReadingsService
            var processReadingsService = new ProcessReadingsService(mockDataRepository.Object, new BusinessRules());
            var fileReadings = processReadingsService.GetFileReadings("");

            //Assert
            Assert.True(fileReadings != null);
            Assert.True(fileReadings.Count() == 4);
            Assert.Equal(FileDataCollection.GetFileMockOutputData(), fileReadings);


        }
    }
}
