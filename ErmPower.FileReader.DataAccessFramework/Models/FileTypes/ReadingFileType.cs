namespace ErmPower.FileReader.DataAccessFramework.Models
{
    public abstract class ReadingFileType
    {
        public string MeterPointCode { get; set; }
        public string SerialNumber { get; set; }
        public string PlantCode { get; set; }
        public string ReadingDateTime { get; set; }
        public string ReadingDataType { get; set; }
        public string Units { get; set; }
        public string ReadingStatus { get; set; }
    }

}
