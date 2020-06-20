using System.IO;

namespace VinanceData
{
    public static class FileLogger
    {
        public static bool LogWarning(string warningMessage)
        {
            string filename = @"C:\Users\S\source\repos\Vinance\log.txt";
            File.AppendAllText(filename, warningMessage);
            return true;
        }
    }
}
