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
using System.Windows.Shapes;

namespace RestaurantOrderingSystem.UI
{
    /// <summary>
    /// Interaction logic for CheckItem.xaml
    /// </summary>
    public partial class CheckItem : Window
    {
        public CheckItem()
        {
            InitializeComponent();
            this.GridForBinding.DataContext = new MenuCategory();
        }
        private void ComboBoxLoadTable(object sender, RoutedEventArgs e)
        {
            var data = Enumerable.Range(1, 10).ToList();
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = data;
            comboBox.SelectedIndex = 0;
        }
        private void ComboBoxSelectionTable(object sender, SelectionChangedEventArgs e)
        {
            // ... Get the ComboBox.
            var comboBox = sender as ComboBox;

            // ... Set SelectedItem as Window Title.
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

        // The information about a new order
        private void AddOrderButtonClick(object sender, RoutedEventArgs e)
        {
            List<string> list = new List<string>();

            // The selected table
            list.Add("Table : " + Tables.Text);

            // Information about selected menu item
            list.Add("Category: " + MenuCategory.Text + ", Item: " + MenuItem.Text + ", Price: $ ...");

            // Is the CheckBox checked
            list.Add("The checkBox is checked: " + CheckBox.IsChecked.ToString());

            // Take the choice from Radio buttons 
            list.Add(((bool)Radio1.IsChecked) ? "Radio button: 1" : "Radio button: 2");

            // Take the information from the calendar
            list.Add("Selected date: " + Calendar.SelectedDate.ToString());

            // Add current date and time
            list.Add("Current date and time: " + DateTime.Now.ToString());

            // Export the result in external *.txt file
            //Write(list);

            this.Close();
        }
    }
}
