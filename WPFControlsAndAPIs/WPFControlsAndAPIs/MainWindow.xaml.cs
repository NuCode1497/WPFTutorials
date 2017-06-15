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
using System.Windows.Annotations;
using System.Windows.Annotations.Storage;
using System.IO;
using System.Windows.Markup;
using AutoLotDAL2.Repos;

namespace WPFControlsAndAPIs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            #region Ink
            this.myInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            this.inkRadio.IsChecked = true;
            this.comboColors.SelectedIndex = 0;
            #endregion
            #region Document
            PopulateDocument();
            EnableAnnotations();
            btnSaveDoc.Click += (o, s) =>
            {
                using (FileStream fStream = File.Open("documentData.xaml", FileMode.Create))
                {
                    XamlWriter.Save(this.myDocumentReader.Document, fStream);
                }
            };
            btnLoadDoc.Click += (o, s) =>
            {
                using (FileStream fstream = File.Open("documentData.xaml", FileMode.Open))
                {
                    try
                    {
                        FlowDocument doc = XamlReader.Load(fstream) as FlowDocument;
                        this.myDocumentReader.Document = doc;
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message, "Error Loading Doc!"); }
                }
            };
            #endregion
            #region Data Binding
            SetBindings();
            #endregion
            #region DataGrid
            ConfigureGrid();
            #endregion
        }

        #region Ink
        private void RadioButtonClicked(object sender, RoutedEventArgs e)
        {
            switch((sender as RadioButton)?.Content.ToString())
            {
                case "Ink Mode!":
                    this.myInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
                    break;
                case "Erase Mode!":
                    this.myInkCanvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
                    break;
                case "Select Mode!":
                    this.myInkCanvas.EditingMode = InkCanvasEditingMode.Select;
                    break;

            }
        }

        private void ColorChanged(object sender, SelectionChangedEventArgs e)
        {
            //get the selected item in the combo box
            string colorToUse = (this.comboColors.SelectedItem as StackPanel)?.Tag.ToString();

            //change the color used to render the strokes
            this.myInkCanvas.DefaultDrawingAttributes.Color = (Color)ColorConverter.ConvertFromString(colorToUse);

        }
        #endregion
        #region Document
        private void PopulateDocument()
        {
            this.listOfFunFacts.FontSize = 14;
            this.listOfFunFacts.MarkerStyle = TextMarkerStyle.Circle;
            this.listOfFunFacts.ListItems.Add(new ListItem(new Paragraph(new Run("Fixed documents are for WYSIWYG print ready docs!"))));
            this.listOfFunFacts.ListItems.Add(new ListItem(new Paragraph(new Run("Flow documents are read only!"))));
            this.listOfFunFacts.ListItems.Add(new ListItem(new Paragraph(new Run("BlockUIContainer allows you to embed WPF controls in the document!"))));

            Run prefix = new Run("This paragraph was generated ");

            Bold b = new Bold();
            Run infix = new Run("dynamically");
            infix.Foreground = Brushes.Red;
            infix.FontSize = 30;
            b.Inlines.Add(infix);

            Run suffix = new Run(" at runtime!");

            this.paraBodyText.Inlines.Add(prefix);
            this.paraBodyText.Inlines.Add(infix);
            this.paraBodyText.Inlines.Add(suffix);
        }
        private void EnableAnnotations()
        {
            //Create the AnnotationService object that works with our FlowDocumentReader.
            AnnotationService anoService = new AnnotationService(myDocumentReader);
            //Create a MemoryStream that will hld the annotations.
            MemoryStream anoStream = new MemoryStream();
            //Now, create an XML-based store based on the MemoryStream.
            //You could use this object to programmatically add, delete, or find annotations.
            AnnotationStore store = new XmlStreamStore(anoStream);
            //Enable the annotation services.
            anoService.Enable(store);

        }
        #endregion
        #region Data Binding
        private void SetBindings()
        {
            //Create a new Binding object.
            Binding b = new Binding();
            //Register the converter, source, and path.
            b.Converter = new MyDoubleConverter();
            b.Source = this.mySB;
            b.Path = new PropertyPath("Value");

            //Call the SetBinding method on the Label.
            this.labelSBThumb.SetBinding(Label.ContentProperty, b);
        }
        #endregion
        #region DataGrid
        private void ConfigureGrid()
        {
            using (var repo = new CarRepo())
            {
                //Build a LINQ query that gets back some data from the Inventory table
                gridInventory.ItemsSource = repo.GetAll().Select(x => new { x.CarId, x.Make, x.Color, x.CarNickName });
            }
        }
        #endregion
    }
}
