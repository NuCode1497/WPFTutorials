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
using System.IO;
using System.Windows.Markup;

namespace MyXamlPad
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //check if there is a xaml file in folder already
            if(File.Exists("YourXaml.xaml"))
            {
                txtXamlData.Text = File.ReadAllText("YourXaml.xaml");
            }
            else
            {
                txtXamlData.Text =
                    "<Window xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"\n" +
                    "xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\"\n" +
                    "Height =\"400\" Width =\"500\" WindowStartupLocation=\"CenterScreen\"\n" +
                    "Title=\"Your XMAL Window\">\n" +
                    "<StackPanel>\n" +
                    "</StackPanel>\n" +
                    "</Window>";
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            File.WriteAllText("YourXaml.xaml", txtXamlData.Text);
            Application.Current.Shutdown();
        }

        private void btnViewXaml_Click(object sender, RoutedEventArgs e)
        {
            //Write out the data in the text block to a local *.xaml file
            File.WriteAllText("YourXaml.xaml", txtXamlData.Text);
            //This is the window that will be dynamically XAML-ed
            Window myWindow = null;
            //Open local *.xaml file
            try
            {
                using (Stream s = File.Open("YourXaml.xaml", FileMode.Open))
                {
                    //Connect the XAML to the Window object
                    myWindow = (Window)XamlReader.Load(s);

                    //Show window as a dialog and clean up
                    myWindow.ShowDialog();
                    myWindow.Close();
                    myWindow = null;
                }
            }
            catch (XamlParseException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
