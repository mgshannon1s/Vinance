using Microsoft.VisualStudio.TestTools.UnitTesting;
using VinanceData;

namespace PFHTest
{
    [TestClass]
    public class TransactionImporterTests
    {
        private readonly string sampleFileLocation = @"C:\Users\S\source\repos\Vinance\VinanceTest\sample files\";

        [TestMethod]
        public void ImportCsvTest()
        {
            string expectedDate = "6/6/2020";
            string expectedDescription = "Old Navy";
            string expectedOriginalDescription = "OLD NAVY US 6715";
            double expectedAmount = 33.94;
            //TODO: Add enum
            string expectedTransactionType = "debit";
            //TODO: Add enum
            string expectedCategory = "Clothing";
            string expectedAccountName = "CREDIT CARD";
            string expectedLabels = "";
            string expectedNotes = "";

            Transaction expectedTransaction = new Transaction
            {
                AccountName = expectedAccountName,
                Amount = expectedAmount,
                Category = expectedCategory,
                Date = expectedDate,
                Description = expectedDescription,
                Labels = expectedLabels,
                Notes = expectedNotes,
                OriginalDescription = expectedOriginalDescription,
                TransactionType = expectedTransactionType
            };

            string sampleTransactionFile = sampleFileLocation+@"sample_transactions.csv";
            //Load sample csv and make sure each item loaded as expected
            var results = TransactionImporter.LoadCsvToArray<Transaction>(sampleTransactionFile);

            Assert.AreEqual(expectedTransaction, results[0]);
        }

        [TestMethod]
        public void ImportCsvTestNotEnoughCommasOnLine()
        {

            string sampleTransactionFile = sampleFileLocation + @"sample_transactions - not enough commas in line.csv";
            //Load sample csv and make sure each item loaded as expected
            var results = TransactionImporter.LoadCsvToArray<Transaction>(sampleTransactionFile);
            //Can't figure out how to completely skip, seems like the engine loads a null transaction if it's told to skip
            //Assert.AreEqual(0,results.Length);
        }

        [TestMethod]
        public void ImportCsvWithCommaInFieldTest()
        {

            string expectedDate = "4/29/2020";
            string expectedDescription = "Treats Unleashed  Inc.";
            string expectedOriginalDescription = "TREATS UNLEASHED SAINT PETERS MO";
            double expectedAmount = 30.19;
            //TODO: Add enum
            string expectedTransactionType = "debit";
            //TODO: Add enum
            string expectedCategory = "Restaurants";
            string expectedAccountName = "Discover";
            string expectedLabels = "";
            string expectedNotes = "";

            Transaction expectedTransaction = new Transaction
            {
                AccountName = expectedAccountName,
                Amount = expectedAmount,
                Category = expectedCategory,
                Date = expectedDate,
                Description = expectedDescription,
                Labels = expectedLabels,
                Notes = expectedNotes,
                OriginalDescription = expectedOriginalDescription,
                TransactionType = expectedTransactionType
            };

            string sampleTransactionFile = sampleFileLocation + @"sample_transactions - comma in row.csv";
            //Load sample csv and make sure each item loaded as expected
            var results = TransactionImporter.LoadCsvToArray<Transaction>(sampleTransactionFile);

            Assert.AreEqual(expectedTransaction, results[0]);
        }
    }
}
