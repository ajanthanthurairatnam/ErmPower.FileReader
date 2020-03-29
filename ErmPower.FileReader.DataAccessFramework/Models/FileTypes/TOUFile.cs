using System;
using System.Collections.Generic;
using System.Text;

namespace ErmPower.FileReader.DataAccessFramework.Models
{
    public class TOUFile : ReadingFileType
    {
        public decimal Energy { get; set; }
        public decimal MaximumDemand { get; set; }
        public string TimeofMaxDemand  { get; set; }
        public string Period { get; set; }
        public bool DLSActive { get; set; }
        public int BillingResetCount { get; set; }
        public string BillingResetDateTime  { get; set; }
        public string Rate { get; set; }
    }
}
