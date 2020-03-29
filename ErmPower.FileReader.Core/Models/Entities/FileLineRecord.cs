namespace ErmPower.FileReader.Core.Models
{
    /// <summary>
    /// Contains Median Value In Addition To LineData
    /// </summary>
    public class FileLineRecord:FileLineData
    {
        public decimal ReadingMedianValue { get; set; }
    }
}

