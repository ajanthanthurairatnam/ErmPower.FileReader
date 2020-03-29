using ErmPower.FileReader.DataAccessFramework.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErmPower.FileReader.DataAccessFramework.Services
{
    public interface ILPFileLineDataReaderService
    {
        IEnumerable<LPFile> ReadLPFileLines(string fileWithFullPath);
    }
}
