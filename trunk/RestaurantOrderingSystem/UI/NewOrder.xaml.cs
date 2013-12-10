using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.IO;
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
using System.Windows.Shapes;
using System.Windows.Threading;
using RestaurantOrderingSystem.UI;

namespace RestaurantOrderingSystem
{
    /// <summary>
    /// Interaction logic for NewOrder.xaml
    /// </summary>
    public partial class NewOrder : Window
    {
        private decimal totalPrice = 0;
        private int countItem = 0;

        public NewOrder()
        {
            InitializeComponent();
        }

        // Get data for ComboBox about Tables
        private void ComboBoxLoadTable(object sender, RoutedEventArgs e)
        {
            var data = Enumerable.Range(1, 10).ToList();
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = data;
            comboBox.SelectedIndex = 0;
        }

        // Get all categories from Database
        private void ComboBoxLoadMenuCategory(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();

            try
            {
                string myConnection = @"provider=microsoft.jet.oledb.4.0;data source=..\..\Database\Menu.mdb";
                OleDbConnection myConn = new OleDbConnection(myConnection);

                // Open connection to database
                myConn.Open();

                string selectString = "SELECT Type FROM Menu";
                OleDbCommand createCommand = new OleDbCommand(selectString, myConn);
                createCommand.ExecuteNonQuery();

                OleDbDataAdapter dataAdp = new OleDbDataAdapter(createCommand);
                DataSet myDataSet = new DataSet();
                dataAdp.Fill(myDataSet, "Menu");

                int rowMax = myDataSet.Tables[0].Rows.Count;
                for (int n = 0; n < rowMax; n++)
                {
                    data.Add(myDataSet.Tables[0].Rows[n].ItemArray[0].ToString());
                }

                // Close connection to database
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = data.Distinct();
            comboBox.SelectedIndex = 0;
        }

        // Get all items for selected category from Database
        private void ComboBoxLoadMenuItem(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            try
            {
                string myConnection = @"provider=microsoft.jet.oledb.4.0;data source=..\..\Database\Menu.mdb";
                OleDbConnection myConn = new OleDbConnection(myConnection);

                // Open connection to database
                myConn.Open();
                string selectedType = this.MenuCategory.SelectedItem.ToString();
                string selectString = "SELECT Item FROM Menu WHERE Type='" + selectedType + "'";
                OleDbCommand createCommand = new OleDbCommand(selectString, myConn);
                createCommand.ExecuteNonQuery();
                OleDbDataAdapter dataAdp = new OleDbDataAdapter(createCommand);
                DataSet myDataSet = new DataSet();
                dataAdp.Fill(myDataSet, "Menu");
                int rowMax = myDataSet.Tables[0].Rows.Count;
                for (int n = 0; n < rowMax; n++)
                {
                    data.Add(myDataSet.Tables[0].Rows[n].ItemArray[0].ToString());
                }

                // Close connection to database
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.MenuItem.ItemsSource = data.Distinct();
            this.MenuItem.SelectedIndex = 0;
        }

        // Selected table
        private void ComboBoxSelectionTable(object sender, SelectionChangedEventArgs e)
        {
            // Get the ComboBox
            var comboBox = sender as ComboBox;

            // Set SelectedItem as Window Title
            string value = comboBox.SelectedItem as string;
            this.Title = "Selected: " + value;
        }

        // Selected category from the menu
        private void ComboBoxSelectionMenuCategory(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            string value = comboBox.SelectedItem as string;
            this.Title = "Selected: " + value;
            ComboBoxLoadMenuItem(null, null);
        }

        // Selected item from the category
        private void ComboBoxSelectionMenuItem(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            string value = comboBox.SelectedItem as string;
            this.Title = "Selected: " + value;
            PriceItem();
        }

        // Close the NewOrder window
        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // The information about a new order
        private void AddOrderButtonClick(object sender, RoutedEventArgs e)
        {
            // Takes the information from the calendar
            // Calendar.SelectedDate.ToString());

            // Create a cashier
            Cashier cashier = new Cashier("Pepa");

            // Export the results to Database MDB file
            string myConnection = @"provider=microsoft.jet.oledb.4.0;data source=..\..\Database\Orders.mdb";
            OleDbConnection myConn = new OleDbConnection(myConnection);
            string myInsertQuery = "INSERT INTO Orders values('" +
                (LastOrderID() + 1) + "','" +
                this.Tables.Text + "','" +
                DateTime.Now + "','" +
                DateTime.Now + "','" +
                "closed" + "','" +
                this.totalPrice + "','" +
                this.BoxPersonName.Text + "','" +
                cashier.Name + "','" +
                Login.imputName + "')";
            OleDbCommand myCommand = new OleDbCommand(myInsertQuery);
            myCommand.Connection = myConn;

            // Open connection to database
            myConn.Open();
            try
            {
                myCommand.ExecuteNonQuery();
                MessageBox.Show(String.Format("A new order {0} was created!", LastOrderID() + 1));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            // Close connection to database
            myConn.Close();

            this.Hide();

            // Update the information in MainWindow
            MainWindow main = new MainWindow();
            main.Show();

            // Close the 1st opened MainWindow
            Application.Current.Windows[0].Close();

            // Close the NewOrder window
            this.Close();
        }

        // Find the last Order ID from the list of orders in Database
        private int LastOrderID()
        {
            string result = String.Empty;
            try
            {
                string myConnection = @"provider=microsoft.jet.oledb.4.0;data source=..\..\Database\Orders.mdb";
                OleDbConnection myConn = new OleDbConnection(myConnection);

                // Open connection to database
                myConn.Open();

                string selectString = "SELECT ID FROM Orders";
                OleDbCommand createCommand = new OleDbCommand(selectString, myConn);
                createCommand.ExecuteNonQuery();

                OleDbDataAdapter dataAdp = new OleDbDataAdapter(createCommand);
                DataSet myDataSet = new DataSet();
                dataAdp.Fill(myDataSet, "Orders");

                int rowMax = myDataSet.Tables[0].Rows.Count;
                result = myDataSet.Tables[0].Rows[rowMax - 1].ItemArray[0].ToString();

                // Close connection to database
                myConn.Close();

                return int.Parse(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }

        // Takes the price for the current item from Database
        private void PriceItem()
        {
            double priceItem = 0;
            try
            {
                string myConnection = @"provider=microsoft.jet.oledb.4.0;data source=..\..\Database\Menu.mdb";
                OleDbConnection myConn = new OleDbConnection(myConnection);

                // Open connection to database
                myConn.Open();

                if (this.MenuItem.SelectedItem != null)
                {
                    string selectedItem = this.MenuItem.SelectedItem.ToString();

                    string selectString = "SELECT Price FROM Menu WHERE Item='" + selectedItem + "'";
                    OleDbCommand createCommand = new OleDbCommand(selectString, myConn);
                    createCommand.ExecuteNonQuery();
                    OleDbDataReader myReader = createCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        priceItem = (double)myReader["Price"];
                    }
                    myReader.Close();
                }

                // Close connection to database
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.BlockPrice.Text = "$" + priceItem.ToString();
        }

        // Calculate the final price for the current Item
        private decimal Price()
        {
            decimal priceItem = decimal.Parse(BlockPrice.Text.ToString().Remove(0, 1));
            decimal quantityItem = decimal.Parse(BoxQuantity.Text);
            decimal discountItem = decimal.Parse(this.BoxDiscount.Text);
            return (priceItem * quantityItem) - ((priceItem * quantityItem) * discountItem / 100);
        }

        // Add some Item in the current order
        private void AddItemButtonClick(object sender, RoutedEventArgs e)
        {
            totalPrice += Price();
            countItem++;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(
                countItem + ". " +
                this.MenuItem.SelectedValue + ": " +
                this.BoxQuantity.Text + " x " +
                this.BlockPrice.Text + " (" +
                ((decimal.Parse(this.BoxDiscount.Text) > 0) ? "-" : "") + this.BoxDiscount.Text + "%) = $" +
                Price()
                );
            this.ListOrder.Items.Add(sb.ToString());
        }

        // Clear all Item records from the order
        private void CancelButtonItem(object sender, RoutedEventArgs e)
        {
            this.ListOrder.Items.Clear();
            countItem = 0;
            totalPrice = 0;
        }
    }
}