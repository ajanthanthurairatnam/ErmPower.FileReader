using ErmPower.FileReader.Utilities.Models;

namespace ErmPower.FileReader.Utilities.Services
{
    public interface IConfigurationProviderService
    {
        FolderPathConfiguration GetFolderPathSettings();

        FolderPathConfiguration CreateFolderPath(string folderPath);

        FolderPathConfiguration ValidateAndObtainFolderConfiguration();
    }
}
