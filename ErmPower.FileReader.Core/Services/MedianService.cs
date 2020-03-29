using System.Collections.Generic;
using System.Linq;

namespace ErmPower.FileReader.Core.Services
{
    public class MedianService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public decimal CalculateMedian(IEnumerable<decimal> numbers)
        {
            var sorted = (from number in numbers
                          orderby number ascending
                          select number).ToList();

            int middle = (int)(sorted.Count() + 1) / 2;

            return (sorted.Count() % 2 != 0) ? sorted[middle - 1] : (sorted[middle - 1] + sorted[middle]) / 2;

        }

    }
}
