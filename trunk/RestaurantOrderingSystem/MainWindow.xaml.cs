using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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
using RestaurantOrderingSystem.UI;

namespace RestaurantOrderingSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //if (Login.IsOpen)
            //{
            //    Login.IsOpen = true;
            //    Login login = new Login();
            //    login.Show();
            //    this.Close();
            //}
            //else
            //{
            //    // Clock
                System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
                timer.Tick += new EventHandler(TimerTick);
                timer.Interval = new TimeSpan(0, 0, 1);
                timer.Start();

                InitializeComponent();

                // List of orders
                LoadTable();
            //}
        }

        // Clock method
        private void TimerTick(object sender, EventArgs e)
        {
            clock.Content = DateTime.Now.ToString("HH:mm:ss");
        }

        private void LoadTable()
        {
            try
            {
                string myConnection = @"provider=microsoft.jet.oledb.4.0;data source=..\..\Database\Orders.mdb";
                OleDbConnection myConn = new OleDbConnection(myConnection);

                // Open connection to database
                myConn.Open();

                string selectString = "SELECT * FROM Orders";
                OleDbCommand createCommand = new OleDbCommand(selectString, myConn);
                createCommand.ExecuteNonQuery();

                OleDbDataAdapter dataAdp = new OleDbDataAdapter(createCommand);
                DataTable dt = new DataTable("Orders");
                dataAdp.Fill(dt);
                OrdersDataGrid.ItemsSource = dt.DefaultView;
                dataAdp.Update(dt);

                // Close connection to database
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Create a new order
        private void NewOrderButtonClick(object sender, RoutedEventArgs e)
        {
            //this.Hide();
            NewOrder window = new NewOrder();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();
            //this.Close();   
        }

        // Show some order
        private void ShowOrderButtonClick(object sender, RoutedEventArgs e)
        {

        }

        // Close the main window
        private void LogOffButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
