using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ErmPower.FileReader.ConsoleUserInterface.Utilities
{
    public static class Helper
    {
        public static string FolderPath { get; set; } = ConfigurationManager.AppSettings["FolderPath"];
    }
}
