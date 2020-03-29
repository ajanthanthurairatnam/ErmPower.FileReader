using ErmPower.FileReader.Core.Models;
using System;

namespace ErmPower.FileReader.Business.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class BusinessRules
    {
        public Func<FileLineRecord, bool> ReadingCondition = e => (e.ReadingValue > (e.ReadingMedianValue * (decimal)(1.2))) || (e.ReadingValue < (e.ReadingMedianValue));
    }
}
