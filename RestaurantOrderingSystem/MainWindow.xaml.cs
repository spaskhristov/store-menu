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
            if (Login.IsOpen)
            {
                Login.IsOpen = true;
                Login login = new Login();
                login.Show();
                this.Close();
            }
            else
            {
                // Clock
                System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
                timer.Tick += new EventHandler(TimerTick);
                timer.Interval = new TimeSpan(0, 0, 1);
                timer.Start();

                InitializeComponent();

                // List of images
                images.DataContext = new[] 
                {
                    new { Title="Orange", Image="/Images/Orange.png" },
                    new { Title="Apple", Image="/Images/Apple.png" },
                    new { Title="Cherry cake", Image="/Images/Cherry cake.png" },
                    new { Title="Strawberry cake", Image="/Images/Strawberry cake.png" },
                    new { Title="Strawberry icecream", Image="/Images/Strawberry icecream.png" },
                    new { Title="Toast", Image="/Images/Toast.png" },
                    new { Title="Spaghetti", Image="/Images/Spaghetti.png" },
                    new { Title="Pizza", Image="/Images/Pizza.png" },
                    new { Title="Meal", Image="/Images/Meal.png" },
                    new { Title="Tea", Image="/Images/Tea.png" },
                    new { Title="BlackTea", Image="/Images/BlackTea.png" },
                    new { Title="Coffee", Image="/Images/Coffee.png" },
                    new { Title="Hot Chocolate", Image="/Images/Hot Chocolate.png" },
                    new { Title="Milkshake Vanilla", Image="/Images/Milkshake Vanilla.png" },
                    new { Title="Wine", Image="/Images/Wine.png" },
                    new { Title="Beer", Image="/Images/Beer.png" }
                };

                // Table with list of orders
                LoadTable();
            }
        }

        // Clock method
        private void TimerTick(object sender, EventArgs e)
        {
            clock.Content = DateTime.Now.ToString("HH:mm:ss");
        }

        // Load all orders from the Database in a table
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
                CustomException myCustom = new CustomException();
                myCustom.CustomMessage = ex.Message;
                MessageBox.Show(myCustom.CustomMessage);
            }
        }

        // Create a new order
        private void NewOrderButtonClick(object sender, RoutedEventArgs e)
        {
            NewOrder window = new NewOrder();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();
        }

        // Show some created order
        private void ShowOrderButtonClick(object sender, RoutedEventArgs e)
        {
            // TODO: ...
        }

        // Close the main window
        private void LogOffButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonClickTable1(object sender, RoutedEventArgs e)
        {
            if (tb1.IsChecked == true)
            {
                Table1.Background = new SolidColorBrush(Colors.Red);
            }
            else
            {

                Table1.Background = new SolidColorBrush(Colors.LightGreen);
            }

            //Table1.Background = new SolidColorBrush(Colors.Green); 
        }

        private void ButtonClickTable2(object sender, RoutedEventArgs e)
        {
            if (tb2.IsChecked == true)
            {
                Table2.Background = new SolidColorBrush(Colors.Red);
            }
            else
            {

                Table2.Background = new SolidColorBrush(Colors.LightGreen);
            }
        }

        private void ButtonClickTable3(object sender, RoutedEventArgs e)
        {
            if (tb3.IsChecked == true)
            {
                Table3.Background = new SolidColorBrush(Colors.Red);
            }
            else
            {

                Table3.Background = new SolidColorBrush(Colors.LightGreen);
            }
        }

        private void ButtonClickTable4(object sender, RoutedEventArgs e)
        {
            if (tb4.IsChecked == true)
            {
                Table4.Background = new SolidColorBrush(Colors.Red);
            }
            else
            {

                Table4.Background = new SolidColorBrush(Colors.LightGreen);
            }
        }

        private void ButtonClickTable5(object sender, RoutedEventArgs e)
        {
            if (tb5.IsChecked == true)
            {
                Table5.Background = new SolidColorBrush(Colors.Red);
            }
            else
            {

                Table5.Background = new SolidColorBrush(Colors.LightGreen);
            }
        }

        private void ButtonClickTable6(object sender, RoutedEventArgs e)
        {
            if (tb6.IsChecked == true)
            {
                Table6.Background = new SolidColorBrush(Colors.Red);
            }
            else
            {

                Table6.Background = new SolidColorBrush(Colors.LightGreen);
            }
        }

        private void ButtonClickTable7(object sender, RoutedEventArgs e)
        {
            if (tb7.IsChecked == true)
            {
                Table7.Background = new SolidColorBrush(Colors.Red);
            }
            else
            {

                Table7.Background = new SolidColorBrush(Colors.LightGreen);
            }
        }

        private void ButtonClickTable8(object sender, RoutedEventArgs e)
        {
            if (tb8.IsChecked == true)
            {
                Table8.Background = new SolidColorBrush(Colors.Red);
            }
            else
            {

                Table8.Background = new SolidColorBrush(Colors.LightGreen);
            }
        }

        private void ButtonOpenCheckItemClick(object sender, RoutedEventArgs e)
        {
            CheckItem window = new CheckItem();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();
        }

        private void FindOrderButtonClick(object sender, RoutedEventArgs e)
        {
            List<DataRow> data = new List<DataRow>();

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
                DataSet myDataSet = new DataSet();
                dataAdp.Fill(myDataSet, "Orders");

                int rowMax = myDataSet.Tables[0].Rows.Count;

                if (this.TextBoxSearch.Text == null || this.TextBoxSearch.Text == "")
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    bool isFound = false;
                    for (int n = 0; n < rowMax; n++)
                    {
                        if (myDataSet.Tables[0].Rows[n].ItemArray[0].ToString() == this.TextBoxSearch.Text)
                        {
                            MessageBox.Show(
                                "Order " + this.TextBoxSearch.Text +
                                "\nDate: " + myDataSet.Tables[0].Rows[n].ItemArray[2] +
                                "\nTable: " + myDataSet.Tables[0].Rows[n].ItemArray[1] +
                                "\nStatus: " + myDataSet.Tables[0].Rows[n].ItemArray[4] +
                                "\nTotal: $" + myDataSet.Tables[0].Rows[n].ItemArray[5] +
                                "\nClient: " + myDataSet.Tables[0].Rows[n].ItemArray[6] +
                                "\nWaitress: " + myDataSet.Tables[0].Rows[n].ItemArray[8]
                                );
                            isFound = true;
                            break;
                        }
                    }
                    if (!isFound)
                    {
                        throw new EntryPointNotFoundException("Order " + this.TextBoxSearch.Text + " was not found in database!");
                    }
                }

                // Close connection to database
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Clear the search field
        private void ClearSearchButtonClick(object sender, RoutedEventArgs e)
        {
            this.TextBoxSearch.Text = String.Empty;
        }
    }
}
