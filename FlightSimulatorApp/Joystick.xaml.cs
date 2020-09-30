using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace AIRPLANE
{
    /// <summary>
    /// Interaction logic for Joystick.xaml
    /// </summary>
    public partial class Joystick : UserControl,INotifyPropertyChanged
    {

        private double x;
        public double X { get { return x; } set { x = value; PropertyChanged(this, new PropertyChangedEventArgs("x")); } }

        private double y;
        public double Y { get { return y; } set { y = value; PropertyChanged(this, new PropertyChangedEventArgs("y")); } }


        private bool ispressed = false;
        private double xValue, yValue;

        public event PropertyChangedEventHandler PropertyChanged;

        public Joystick()
        {
            InitializeComponent();
        }

        private void Knob_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(Knob);
            ispressed = true;
                   }

        private void Knob_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(null);
            ispressed = false;
            knobPosition.X = 0;
            knobPosition.Y = 0; 
        }

        private void Knob_MouseMove(object sender, MouseEventArgs e)
        {
            if (ispressed)
            {
                double radius = Base.Width / 2;
                xValue = e.GetPosition(Base).X-radius;
                yValue = e.GetPosition(Base).Y - radius;
                Vector v = new Vector(xValue, yValue);
                if (v.Length >= (Base.Width/2))
                {
                    v.Normalize();
                    knobPosition.X = v.X * radius;
                    knobPosition.Y = v.Y * radius;
                }
                else
                {
                    knobPosition.X = xValue;
                    knobPosition.Y = yValue;
                }

                X = knobPosition.X / radius;
                Y = knobPosition.Y / radius;
            }
        }

        //    public delegate void centerKnob_Completed();

    }
}
