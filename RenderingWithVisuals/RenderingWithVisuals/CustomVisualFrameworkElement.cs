using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RenderingWithVisuals
{
    public class CustomVisualFrameworkElement : FrameworkElement
    {
        //A collection of all the visuals we are building
        VisualCollection theVisuals;

        public CustomVisualFrameworkElement()
        {
            //Fil the VisualCollection with a few DrawingVisual objects
            //the ctor arg represents the owner of the visuals
            theVisuals = new VisualCollection(this);
            theVisuals.Add(AddRect());
            theVisuals.Add(AddCircle());

            this.MouseDown += MyVisualHost_MouseDown;
        }

        private void MyVisualHost_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //Figure out where the user clicked
            Point pt = e.GetPosition((UIElement)sender);

            //Call helper function via delegate to see if we clicked on a visual
            VisualTreeHelper.HitTest(this, null, new HitTestResultCallback(myCallBack), new PointHitTestParameters(pt));
        }

        public HitTestResultBehavior myCallBack(HitTestResult result)
        {
            //Toggle between a skewed rendering and normal rendering if a visual was clicked
            if(result.VisualHit.GetType() == typeof(DrawingVisual))
            {
                if(((DrawingVisual)result.VisualHit).Transform == null)
                {
                    ((DrawingVisual)result.VisualHit).Transform = new SkewTransform(7, 7);
                }
                else
                {
                    ((DrawingVisual)result.VisualHit).Transform = null;
                }
            }

            return HitTestResultBehavior.Stop;
        }

        private Visual AddCircle()
        {
            DrawingVisual drawingVisual = new DrawingVisual();

            //Retrieve the DrawingConetxt in order to create new drawing content
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                Rect rect = new Rect(new Point(160, 100), new Size(320, 80));
                drawingContext.DrawEllipse(Brushes.DarkBlue, null, new Point(70, 90), 40, 50);
            }
            return drawingVisual;
        }

        private Visual AddRect()
        {
            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                Rect rect = new Rect(new Point(160, 100), new Size(320, 80));
                drawingContext.DrawRectangle(Brushes.Tomato, null, rect);
            }
            return drawingVisual;
        }

        protected override int VisualChildrenCount
        {
            get { return theVisuals.Count; }
        }

        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= theVisuals.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            return theVisuals[index];
        }
    }
}
