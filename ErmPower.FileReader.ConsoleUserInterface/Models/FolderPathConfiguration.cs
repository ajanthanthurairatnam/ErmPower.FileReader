using ErmPower.FileReader.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErmPower.FileReader.Utilities.Models
{
    public class FolderPathConfiguration
    {
        public ResultStatus FolderPathConfigurationStatus { get; set; }
        public string FolderPath { get; set; }
        public string ConfigurationResult { get; set; }
    }

}
