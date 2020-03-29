using CsvHelper.Configuration;

namespace ErmPower.FileReader.DataAccessFramework.Models
{
    public class TOUFileMap : ClassMap<TOUFile>
    {
        public TOUFileMap()
        {
            Map(m => m.MeterPointCode).Name("MeterPoint Code");
            Map(m => m.SerialNumber).Name("Serial Number");
            Map(m => m.PlantCode).Name("Plant Code");
            Map(m => m.ReadingDateTime).Name("Date/Time");
            Map(m => m.ReadingDataType).Name("Data Type");
            Map(m => m.Energy).Name("Energy");
            Map(m => m.MaximumDemand).Name("Maximum Demand");
            Map(m => m.TimeofMaxDemand).Name("Time of Max Demand");
            Map(m => m.Units).Name("Units");
            Map(m => m.ReadingStatus).Name("Status");
            Map(m => m.Period).Name("Period");
            Map(m => m.DLSActive).Name("DLS Active");
            Map(m => m.BillingResetCount).Name("Billing Reset Count");
            Map(m => m.BillingResetDateTime).Name("Billing Reset Date/Time");
            Map(m => m.Rate).Name("Rate");
        }
    }
}
