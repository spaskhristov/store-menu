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
        public static  bool isOpenLogin = true;
        public Login()
        {
            InitializeComponent();
        }
        public static bool IsOpenLogin
        {
            get
            {
                return isOpenLogin;
            }
            set
            {
                isOpenLogin = value;
            }
        }
        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
             try
            {
                string myConnection = @"provider=microsoft.jet.oledb.4.0;data source=..\..\Restaurant\Database\login.mdb";
                OleDbConnection myConn = new OleDbConnection(myConnection);
                string imputName = this.BoxName.Text.Trim();
                string imputPass = this.BoxPassword.Password;
                string selectstring = "SELECT * FROM login WHERE User='" + imputName + "' AND Pass='" + imputPass + "'";
                OleDbCommand selectCommand = new OleDbCommand(selectstring, myConn);
                myConn.Open();
                OleDbDataReader myReader = selectCommand.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count++;
                 }
                if (count == 1)
                {
                    IsOpenLogin = false;
                    this.Hide();
                    MainWindow main = new MainWindow();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Username or password not correct!!!");
                }
                myReader.Close();
                myConn.Close();
                //added change because exe load problems @Tsonko
                myConn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
