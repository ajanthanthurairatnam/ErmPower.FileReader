using CsvHelper.Configuration;

namespace ErmPower.FileReader.DataAccessFramework.Models
{
    public class LPFileMap : ClassMap<LPFile>
    {
        public LPFileMap()
        {
            Map(m => m.MeterPointCode).Name("MeterPoint Code");
            Map(m => m.SerialNumber).Name("Serial Number");
            Map(m => m.PlantCode).Name("Plant Code");
            Map(m => m.ReadingDateTime).Name("Date/Time");
            Map(m => m.ReadingDataType).Name("Data Type");
            Map(m => m.ReadingDataValue).Name("Data Value");
            Map(m => m.Units).Name("Units");
            Map(m => m.ReadingStatus).Name("Status");
          
        }
    }
}
