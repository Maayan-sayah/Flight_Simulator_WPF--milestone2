using System;
using System.Windows;
using System.Windows.Controls;
using AIRPLANE;
using Microsoft.Maps.MapControl.WPF;

namespace WPFTestApplication
{
    public partial class homepage : Window
    {
        private AirplanViewModel vm;
        public homepage(string ip,string port)
        {
            vm = new AirplanViewModel(new MyFlightSimulator());
            try
            {
                vm.connect(ip, port);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            //MessageBox.Show("please enter ip and port:");
            InitializeComponent();
            //Set map to Aerial mode with labels
            
            myMap.Mode = new AerialMode(true);
            JOY.PropertyChanged += (s, e) =>
            {
                vm.vm_Rudder = JOY.X;
                vm.vm_Elevator = JOY.Y;
            };
            DataContext = vm;

            
        }

        private void Joystick_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Joystick_property_changed(AirplanViewModel vm)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            vm.stopandrun();
        }
    }
}