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

        // Get data for ComboBox about Menu category
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

        // Get data for ComboBox about Menu items
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
                    string selectedItem = this.MenuItem.SelectedItem.ToString();        // "Calamari"

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
            this.BlockPrice.Text = priceItem.ToString();
        }

        private void ComboBoxSelectionTable(object sender, SelectionChangedEventArgs e)
        {
            //... Get the ComboBox.
            var comboBox = sender as ComboBox;
            //... Set SelectedItem as Window Title.
            string value = comboBox.SelectedItem as string;
            this.Title = "Selected: " + value;
        }

        private void ComboBoxSelectionMenuCategory(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            string value = comboBox.SelectedItem as string;
            this.Title = "Selected: " + value;
            ComboBoxLoadMenuItem(null, null);
        }

        private void ComboBoxSelectionMenuItem(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            string value = comboBox.SelectedItem as string;
            this.Title = "Selected: " + value;
            PriceItem();
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // The information about a new order
        private void AddOrderButtonClick(object sender, RoutedEventArgs e)
        {
            List<string> list = new List<string>();

            // Information about selected menu item
            list.Add("Category: " + MenuCategory.Text + ", Item: " + MenuItem.Text + ", Price: " + BlockPrice.Text);

            // Take the information from the calendar
            list.Add("Selected date: " + Calendar.SelectedDate.ToString());

            // Add current date and time
            list.Add("Current date and time: " + DateTime.Now.ToString());

            // Export the result in external *.txt file
            Write(list);


            string myConnection = @"provider=microsoft.jet.oledb.4.0;data source=..\..\Database\Orders.mdb";
            OleDbConnection myConn = new OleDbConnection(myConnection);
            string myInsertQuery = "INSERT INTO Orders values('" +
                (Couter() + 1) + "','" +
                this.Tables.Text + "','" +
                2 + "','" +
                DateTime.Now + "','" +
                DateTime.Now + "','" +
                "closed" + "','" +
                100 + "','" +
                "Anonymous" + "','" +
                "Pepa" + "','" +
                "Maria" + "')";
            OleDbCommand myCommand = new OleDbCommand(myInsertQuery);
            myCommand.Connection = myConn;

            // Open connection to database
            myConn.Open();
            try
            {
                myCommand.ExecuteNonQuery();
                MessageBox.Show("records are successfully insert");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            // Close connection to database
            myConn.Close();

            this.Hide();
            MainWindow main = new MainWindow();
            main.Show();
            Application.Current.Windows[0].Close();
            this.Close();
        }

        private int Couter()
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

        private void Write(List<string> results)
        {
            StreamWriter write = new StreamWriter("../../Database/output.txt");
            using (write)
            {
                foreach (var item in results)
                {
                    write.WriteLine(item);
                }
            }
        }

        private decimal Price()
        {
            decimal priceItem = decimal.Parse(BlockPrice.Text.ToString());
            decimal quantityItem = decimal.Parse(BoxQuantity.Text.ToString());
            decimal discountItem = decimal.Parse(this.BoxDiscount.Text.ToString());
            return (priceItem * quantityItem) - ((priceItem * quantityItem) * discountItem);
        }
        int count = 0;
        private void AddItemButtonClick(object sender, RoutedEventArgs e)
        {
            count++;
            StringBuilder sb = new StringBuilder();
            sb.Append(count);
            sb.Append(".");
            sb.Append(this.MenuItem.SelectedValue);
            sb.Append("-");
            sb.Append(this.BoxQuantity.Text.ToString());
            sb.Append("-");
            sb.Append(this.BlockPrice.Text.ToString());
            sb.Append("-");
            sb.Append(Price().ToString());
            this.ListOrder.Items.Add(sb.ToString());
        }

        private void CancelButtonItem(object sender, RoutedEventArgs e)
        {
            this.ListOrder.Items.Clear();
            count = 0;
        }
    }
}