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
using System.Windows.Media.Animation;

namespace SpinningButtonAnimationApp
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

        private bool _isSpinning = false;
        private void btnSpinner_MouseEnter(object sender, MouseEventArgs e)
        {
            if(!_isSpinning)
            {
                _isSpinning = true;
                //Make a double animation object, and register with the Completed event
                var dblAnim = new DoubleAnimation();
                dblAnim.Completed += (o, s) => { _isSpinning = false; };

                //Control the pace of the animation
                dblAnim.Duration = new Duration(TimeSpan.FromSeconds(4));

                //Set the start value and end value
                dblAnim.From = 0;
                dblAnim.To = 360;

                var rt = new RotateTransform();
                btnSpinner.RenderTransform = rt;

                rt.BeginAnimation(RotateTransform.AngleProperty, dblAnim);
            }
        }

        private void btnSpinner_Click(object sender, RoutedEventArgs e)
        {
            var dblAnim = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0
            };
            //reverse when done
            dblAnim.AutoReverse = true;
            btnSpinner.BeginAnimation(Button.OpacityProperty, dblAnim);
        }
    }
}
