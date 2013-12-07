using System;
using System.Collections.Generic;
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

namespace RestaurantOrderingSystem
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public static bool isOpen = true;

        public Login()
        {
            InitializeComponent();
        }

        public static bool IsOpen
        {
            get
            {
                return isOpen;
            }
            set
            {
                isOpen = value;
            }
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string myConnection = @"provider=microsoft.jet.oledb.4.0; data source=..\..\Database\Login.mdb";
                OleDbConnection myConn = new OleDbConnection(myConnection);
                myConn.Open();
                string imputName = this.BoxName.Text.Trim();
                string imputPass = this.BoxPassword.Password;
                string selectString = "SELECT * FROM Login WHERE User='" + imputName + "' AND Pass='" + imputPass + "'";
                OleDbCommand selectCommand = new OleDbCommand(selectString, myConn);
                //myConn.Open();
                OleDbDataReader myReader = selectCommand.ExecuteReader();

                int count = 0;
                while (myReader.Read())
                {
                    count++;
                }

                if (count == 1)
                {
                    IsOpen = false;
                    this.Hide();
                    MainWindow main = new MainWindow();
                    main.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username or password not correct!");
                    myReader.Close();
                    myConn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
