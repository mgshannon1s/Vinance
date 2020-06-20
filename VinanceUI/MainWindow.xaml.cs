using System.Collections.ObjectModel;
using System.Windows;
using VinanceData;
using Utilities;

namespace PersonalFinanceHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Transaction[] transactions;
        public ObservableCollection<Transaction> data = new ObservableCollection<Transaction>();
        public MainWindow()
        {
            transactions = TransactionImporter.LoadCsvToArray<Transaction>(Constants.TransactionFile);
            InitializeComponent();
            foreach (Transaction result in transactions)
            {
                data.Add(result);
            }
            
            transactionsGrid.ItemsSource = data;
        }

        private void UpdateTransactionsButton_click(object sender, RoutedEventArgs e)
        {
            transactions = TransactionImporter.LoadCsvToArray<Transaction>(Constants.TransactionFile);
        }
    }
}
