using ErmPower.FileReader.ConsoleUserInterface.Utilities;
using ErmPower.FileReader.Utilities.Enums;
using ErmPower.FileReader.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace ErmPower.FileReader.Utilities.Services
{
    public class ConfigurationProviderService : IConfigurationProviderService
    {
        private bool _containsFolderPath = Helper.FolderPath != null;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public FolderPathConfiguration GetFolderPathSettings()
        {
            return new FolderPathConfiguration()
            {
                FolderPathConfigurationStatus = _containsFolderPath ? ResultStatus.Success : ResultStatus.Failure,
                FolderPath = _containsFolderPath ? Helper.FolderPath : string.Empty,
                ConfigurationResult = _containsFolderPath ? $"FolderPath set as {Helper.FolderPath}" : "FolderPath not set in configuration"
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns></returns>
        public FolderPathConfiguration CreateFolderPath(string folderPath)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var fullyQualifiedPath = $"{currentDirectory}{folderPath}";

            if (!Directory.Exists(fullyQualifiedPath))
                Directory.CreateDirectory(fullyQualifiedPath);

            return new FolderPathConfiguration()
            {
                FolderPathConfigurationStatus = ResultStatus.Success,
                FolderPath = fullyQualifiedPath,
                ConfigurationResult = $"FolderPath set as {fullyQualifiedPath}"
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public FolderPathConfiguration ValidateAndObtainFolderConfiguration()
        {
            var folderPathConfig = GetFolderPathSettings();

            if (folderPathConfig.FolderPathConfigurationStatus != ResultStatus.Success)
                return folderPathConfig;

            return CreateFolderPath(folderPathConfig.FolderPath);
        }
    }
}
