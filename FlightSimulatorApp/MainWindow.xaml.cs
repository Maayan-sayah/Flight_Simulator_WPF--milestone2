using System;
using System.Collections.Generic;
using System.Configuration;
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


namespace AIRPLANE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_login_Click(object sender, RoutedEventArgs e)
        {
            WPFTestApplication.homepage home;

            try
            {
                home = new WPFTestApplication.homepage(this.ip.Text, this.port.Text);
                this.Close();
                home.ShowDialog();
            }
            catch (Exception ex)
            {
                if (ex.Message == "couldnt connect with this ip/port")
                {
                    MessageBox.Show("couldnt connect with your ip/port, connecting with defult values");
                    try
                    {
                    home = new WPFTestApplication.homepage(ConfigurationManager.AppSettings.Get("defaultIP"), ConfigurationManager.AppSettings.Get("defaultPORT"));
                    this.Close();
                    home.ShowDialog();
                    }
                    catch (Exception e1)
                    {
                        MessageBox.Show("no server to connect to");
                    }

                }
                else if (ex.Message== "no server to connect to")
                {
                    MessageBox.Show("no server to connect to");
                }
            }
        }
    }
}
