using ErmPower.FileReader.Business;
using ErmPower.FileReader.Business.Services;
using ErmPower.FileReader.ConsoleUserInterface.Services;
using ErmPower.FileReader.Core.Services;
using ErmPower.FileReader.Data.Services;
using ErmPower.FileReader.DataAccessFramework.Services;
using ErmPower.FileReader.Utilities.Enums;
using ErmPower.FileReader.Utilities.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ErmPower.FileReader.ConsoleUserInterface
{
    public class Program
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var services = ConfigureServices();
            
            var consoleOutputService = services
                .GetService<IConsoleOutputService>();

            consoleOutputService.GetFileReadingOutput();
        }

        /// <summary>
        /// Register Dependencies Here
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static ServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                           .AddTransient<IConfigurationProviderService, ConfigurationProviderService>()
                           .AddTransient<IFileLineRecordService, LPFileLineRecordService>()
                           .AddTransient<IFileLineRecordService, TOUFileLineRecordService>()
                           .AddTransient<ILPFileLineDataReaderService, LPFileLineDataReaderService>()
                           .AddTransient<ITOULineDataReaderService, TOULineDataReaderService>()
                           .AddTransient<IRepository, FileRepository>()
                           .AddTransient<IProcessReadingsService, ProcessReadingsService>()
                           .AddTransient<BusinessRules, BusinessRules>()
                           .AddTransient<IProcessReadingsService, ProcessReadingsService>()
                           .AddTransient<MedianService, MedianService>()
                           .AddTransient<IConsoleOutputService, ConsoleOutputService>()
                           .BuildServiceProvider();
        }
    }
}
