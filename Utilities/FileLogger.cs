using System.IO;

namespace Utilities
{
    public static class FileLogger
    {
        public static bool LogWarning(string warningMessage)
        {
            File.AppendAllText(Constants.LogFilename, warningMessage);
            return true;
        }
        public static bool LogError(string errorMessage)
        {
            File.AppendAllText(Constants.LogFilename, errorMessage);
            return true;
        }
    }
}
