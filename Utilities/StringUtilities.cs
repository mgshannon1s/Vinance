namespace VinanceData
{
    /// <summary>
    /// String Utilities class will handle operations to the string class
    /// </summary>
    public static class StringUtilities
    {
        public static string ReplaceEmbeddedCommasWithSpaces(string line)
        {
            if (line.Contains("\""))
            {
            
                int locationOfFirstQuote = line.IndexOf("\"");
                int locationOfLastQuote = line.LastIndexOf("\"");
                string sectionWithCommaInFieldValue = line.Substring(locationOfFirstQuote, locationOfLastQuote - locationOfFirstQuote);
                string stringWithCommaRemoved = sectionWithCommaInFieldValue.Replace(",", " ");
                
                return line.Substring(0, locationOfFirstQuote)
                    + stringWithCommaRemoved
                    + line.Substring(locationOfLastQuote);
            }
            return line;
        }
    }
}
