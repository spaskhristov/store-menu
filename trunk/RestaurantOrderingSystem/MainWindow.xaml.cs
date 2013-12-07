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

            //create list for Datagrid table
                var dataDesserts = new List<Dessert>
                    {
                        new Dessert()
                        {
                            ItemDescription = "Orange",
                            Quantity = 1,
                            Price = 1
                        },
                        new Dessert()
                        {
                            ItemDescription = "Apple",
                            Quantity = 1,
                            Price = 1
                        },
                        new Dessert()
                        {
                            ItemDescription = "Cherry Cake",
                            Quantity = 1,
                            Price = 4
                        },
                        new Dessert()
                        {
                            ItemDescription = "Strawberry Cake",
                            Quantity = 1,
                            Price = 5
                        },
                        new Dessert()
                        {
                            ItemDescription = "Strawberry IceCream",
                            Quantity = 1,
                            Price = 2
                        },
                    };                

                InitializeComponent();
                
                //apply datagrid source
                tableDesserts.ItemsSource = dataDesserts;
                
                //list of images
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
                // List of orders
                LoadTable();
            }
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
        //<Image Source="/Images/login.jpg"/>
    }
}
