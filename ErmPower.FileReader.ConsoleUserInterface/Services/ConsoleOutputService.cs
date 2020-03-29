using ErmPower.FileReader.Business;
using ErmPower.FileReader.Utilities.Enums;
using ErmPower.FileReader.Utilities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErmPower.FileReader.ConsoleUserInterface.Services
{
    public class ConsoleOutputService : IConsoleOutputService
    {

        private readonly IProcessReadingsService _processDirectoryService;
        private readonly IConfigurationProviderService _configurationProviderService;
        /// <summary>
        /// 
        /// </summary>
        public ConsoleOutputService(IProcessReadingsService processDirectoryService, IConfigurationProviderService configurationProviderService)
        {
            _processDirectoryService = processDirectoryService;
            _configurationProviderService = configurationProviderService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="folderPath"></param>
        public void GetFileReadingOutput()
        {
            try
            {
                var configuration = _configurationProviderService.ValidateAndObtainFolderConfiguration();

                if (configuration.FolderPathConfigurationStatus != ResultStatus.Success)
                {
                    Console.WriteLine
                                (configuration.ConfigurationResult);
                    return;
                }

                if (_processDirectoryService.GetFileReadings(configuration.FolderPath).Any())
                {
                    foreach (var fileLine in _processDirectoryService.GetFileReadings(configuration.FolderPath))
                    {
                        Console.WriteLine(fileLine);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Unexpected Error Occured. ");
            }

            Console.ReadLine();
        }
    }
}
