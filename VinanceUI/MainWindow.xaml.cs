using System.Collections.ObjectModel;
using System.Windows;
using VinanceData;

namespace PersonalFinanceHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string mintTransactionDownloadUrl = "https://mint.intuit.com/transactionDownload.event?queryNew=&offset=0&filterType=cash&comparableType=8";
        Transaction[] transactions;
        private readonly string transactionFile = @"C:\Users\S\source\repos\Vinance\transactions.csv";
        public ObservableCollection<Transaction> data = new ObservableCollection<Transaction>();
        public MainWindow()
        {
            transactions = TransactionImporter.LoadCsvToArray<Transaction>(transactionFile);
            InitializeComponent();
            foreach (Transaction result in transactions)
            {
                data.Add(result);
            }
            
            transactionsGrid.ItemsSource = data;
        }

        private void UpdateTransactionsButton_click(object sender, RoutedEventArgs e)
        {
            transactions = TransactionImporter.LoadCsvToArray<Transaction>(transactionFile);
        }
    }
}
