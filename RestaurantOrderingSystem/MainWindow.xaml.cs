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

namespace RestaurantOrderingSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        public MainWindow()
        {
            if (!Login.IsOpenLogin)
            {
                //added timer function @Tsonko
                System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
                timer.Tick += new EventHandler(Timer_Tick);
                timer.Interval = new TimeSpan(0, 0, 1);
                timer.Start(); 
                InitializeComponent();
                //Open Page1.xaml
                FrameInWindow.Navigate(new System.Uri("UIPages/Page1.xaml", UriKind.RelativeOrAbsolute));
            }
            else if (Login.IsOpenLogin)
            {
                Login.IsOpenLogin = true;
                Login login = new Login();
                login.Show();
                this.Hide();
            }
        }

        private void Page1(object sender, RoutedEventArgs e)
        {
            FrameInWindow.Navigate(new System.Uri("UIPages/Page1.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Page2(object sender, RoutedEventArgs e)
        {
            FrameInWindow.Navigate(new System.Uri("UIPages/Page2.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Page3(object sender, RoutedEventArgs e)
        {
            FrameInWindow.Navigate(new System.Uri("UIPages/Page3.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Page4(object sender, RoutedEventArgs e)
        {
            FrameInWindow.Navigate(new System.Uri("UIPages/Page4.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Page5(object sender, RoutedEventArgs e)
        {
            FrameInWindow.Navigate(new System.Uri("UIPages/Page5.xaml", UriKind.RelativeOrAbsolute));
        }

        // Close the main window
        private void LogOffButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //timer method
        private void Timer_Tick(object sender, EventArgs e)
        {
            lblDigitalClock.Content = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
