using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using RestaurantOrderingSystem.UI;
using System.ComponentModel;

namespace RestaurantOrderingSystem.UI
{
    /// <summary>
    /// Interaction logic for CheckItem.xaml
    /// </summary>
    public partial class CheckItem : Window, INotifyPropertyChanged
    {
        public ObservableCollection<CheckItem> Items { get; set; }
        public CheckItem()
        {
            //InitializeComponent();
            Items = new ObservableCollection<CheckItem>();
            this.DataContext = this;
            //this.GridNextBinding.DataContext = new MenuCategory();
        }
        private void ComboBoxLoadTable(object sender, RoutedEventArgs e)
        {
            var data = Enumerable.Range(1, 10).ToList();
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = data;
            comboBox.SelectedIndex = 0;
        }

        private void ComboBoxLoadMenuItem(object sender, RoutedEventArgs e)
        {
            try
            {
                string myConnection = @"provider=microsoft.jet.oledb.4.0;data source=..\..\Database\Menu.mdb";
                OleDbConnection myConn = new OleDbConnection(myConnection);

                myConn.Open();

                // TODO: selectedType from ComboBoxLoadMenuCategory
                string selectedType = "Starters";

                string selectString = "SELECT Item FROM Menu WHERE Type='" + selectedType + "'";
                OleDbCommand createCommand = new OleDbCommand(selectString, myConn);
                createCommand.ExecuteNonQuery();

                OleDbDataAdapter dataAdp = new OleDbDataAdapter(createCommand);
                DataSet myDataSet = new DataSet();
                dataAdp.Fill(myDataSet, "Menu");

                int RowMax = myDataSet.Tables[0].Rows.Count;

                // ... A List.
                List<string> data = new List<string>();
                for (int n = 0; n < RowMax; n++)
                {
                    data.Add(myDataSet.Tables[0].Rows[n].ItemArray[0].ToString());
                }

                // ... Get the ComboBox reference.
                var comboBox = sender as ComboBox;

                // ... Assign the ItemsSource to the List.
                comboBox.ItemsSource = data;

                // ... Make the first item selected.
                comboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ComboBoxSelectionTable(object sender, SelectionChangedEventArgs e)
        {
            // ... Get the ComboBox.
            var comboBox = sender as ComboBox;

            // ... Set SelectedItem as Window Title.
            string value = comboBox.SelectedItem as string;
            this.Title = "Selected: " + value;
        }

        private void ComboBoxSelectionMenuCategory(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            string value = comboBox.SelectedItem as string;
            this.Title = "Selected: " + value;
        }

        private void ComboBoxSelectionMenuItem(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            string value = comboBox.SelectedItem as string;
            this.Title = "Selected: " + value;
        }

        private void Radio1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Radio2_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
