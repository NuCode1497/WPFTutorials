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

namespace RenderingWithShapes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private enum SelectedShape
        { Circle, Rectangle, Line }
        private SelectedShape _currentShape;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void circleOption_Click(object sender, RoutedEventArgs e)
        {
            _currentShape = SelectedShape.Circle;
        }

        private void rectOption_Checked(object sender, RoutedEventArgs e)
        {
            _currentShape = SelectedShape.Rectangle;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            _currentShape = SelectedShape.Line;
        }

        private void canvasDrawingArea_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //add a shape on left click

            Shape shapeToRender = null;

            //Configure the correct shape to draw
            switch(_currentShape)
            {
                case SelectedShape.Circle:
                    shapeToRender = new Ellipse() { Height = 35, Width = 35 };
                    RadialGradientBrush brush = new RadialGradientBrush();
                    /*      <GradientStop Color="#FF0017FF" Offset="0"/>
                            <GradientStop Color="#FF46C840" Offset="1"/>
                            <GradientStop Color="#FF912A75" Offset="0.525"/> */
                    brush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF0017FF"), 0));
                    brush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF46C840"), 1));
                    brush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF912A75"), 0.525));
                    shapeToRender.Fill = brush;
                    break;
                case SelectedShape.Rectangle:
                    shapeToRender = new Rectangle() { Fill = Brushes.Red, Height = 35, Width = 35, RadiusX = 10, RadiusY = 10 };
                    break;
                case SelectedShape.Line:
                    shapeToRender = new Line()
                    {
                        Stroke = Brushes.Blue, StrokeThickness = 10, X1 = 0, X2 = 50, Y1 = 0, Y2 = 50,
                        StrokeStartLineCap = PenLineCap.Triangle,
                        StrokeEndLineCap = PenLineCap.Round
                    };
                    break;
                default:
                    return;
            }

            if(FlipCanvas.IsChecked == true)
            {
                shapeToRender.RenderTransform = new RotateTransform(180);
            }

            //set top/left position to draw in the canvas
            Canvas.SetLeft(shapeToRender, e.GetPosition(canvasDrawingArea).X);
            Canvas.SetTop(shapeToRender, e.GetPosition(canvasDrawingArea).Y);

            //Draw
            canvasDrawingArea.Children.Add(shapeToRender);
        }

        private void canvasDrawingArea_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //delete on right click

            //first get the positionof clikc
            Point pt = e.GetPosition((Canvas)sender);

            HitTestResult result = VisualTreeHelper.HitTest(canvasDrawingArea, pt);

            if (result != null)
            {
                canvasDrawingArea.Children.Remove(result.VisualHit as Shape);
            }
        }

        private void FlipCanvas_Click(object sender, RoutedEventArgs e)
        {
            if(FlipCanvas.IsChecked == true)
            {
                RotateTransform rotate = new RotateTransform(180);
                canvasDrawingArea.LayoutTransform = rotate;
            }
            else
            {
                canvasDrawingArea.LayoutTransform = null;
            }
        }
    }
}
