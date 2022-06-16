using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly SqlConnection sqlConnection = null;
        StreamWriter log;
        public MainWindow()
        {
            InitializeComponent();
            log = new StreamWriter("log.txt");
            log.Close();
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataBaseConnection"].ConnectionString);

            sqlConnection.Open();
            if (sqlConnection.State == ConnectionState.Open)
            {
                MessageBox.Show("Database connection error", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
            WriteToLogfile("connected to database");








        }
        public void WriteToLogfile(string status)
        {
            log = new StreamWriter("log.txt", true);
            log.WriteLine($"[{Environment.MachineName}]\t{DateTime.Now}\t\t: " + status);
            log.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
    



        }

        private void Window_Closed(object sender, EventArgs e)
        {
            sqlConnection.Close();
            WriteToLogfile("program finished successfully");
            log.Close();
        }
    }
}
