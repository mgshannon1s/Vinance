using FileHelpers;
using VinanceData;
using Utilities;

namespace VinanceData
{
    public static class TransactionImporter
    {
        public static T[] LoadCsvToArray<T>(string filename) where T : class
        {
            FileHelperEngine<T> engine = new FileHelperEngine<T>();
            engine.BeforeReadRecord += Engine_BeforeReadRecord;

            T[] result = engine.ReadFile(filename);

            return result;
        }

        private static void Engine_BeforeReadRecord(EngineBase engine, FileHelpers.Events.BeforeReadEventArgs e)
        {
            string[] elements = e.RecordLine.Split(',');
            if (elements.Length < Constants.TotalTransactionElements)
            {
                FileLogger.LogWarning("TransactionImporter failed to import line:" + e.RecordLine);
                e.SkipThisRecord = true;
                return;
            }
            e.RecordLine = StringUtilities.ReplaceEmbeddedCommasWithSpaces(e.RecordLine);
        }
    }
}
