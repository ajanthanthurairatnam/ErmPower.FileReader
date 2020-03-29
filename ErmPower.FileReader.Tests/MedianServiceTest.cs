using ErmPower.FileReader.Core.Services;
using ErmPower.FileReader.Data.Services;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Extensions;

namespace ErmPower.FileReader.Tests
{
    public class MedianServiceTest
    {

        /// <summary>
        /// Test Median Calculation
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="expectedMedian"></param>
        [Theory, MemberData(nameof(MedianData))]
        public void CalculateMedian_Success(IEnumerable<decimal> numbers, decimal expectedMedian)
        {
            MedianService medianService = new MedianService();
            Assert.Equal(expectedMedian, medianService.CalculateMedian(numbers));
        }

        /// <summary>
        /// Median Data
        /// </summary>
        public static IEnumerable<object[]> MedianData
        {
            get
            {
                return new[]
                {
                    new object[] { new decimal[] { 1, 2, 3, 4, 5 }, 3 },
                    new object[] { new decimal[] { 3, 13, 7, 5, 21, 23, 39, 23, 40, 23, 14, 12, 56, 23, 29 }, 23 },
                    new object[] { new decimal[] { 3, 5, 7, 12, 13, 14, 21, 23, 23, 23, 23, 29, 40, 56 }, 22 }
                };
            }

        }
    }
}
