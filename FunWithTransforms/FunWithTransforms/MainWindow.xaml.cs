﻿using System;
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

namespace FunWithTransforms
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

        private void btnSkew_Click(object sender, RoutedEventArgs e)
        {
            Face.LayoutTransform = new SkewTransform(40, -20);
        }

        private int deg = 0;
        private void btnRotate_Click(object sender, RoutedEventArgs e)
        {
            deg += 5;
            Face.RenderTransform = new RotateTransform(deg);
        }

        private void btnFlip_Click(object sender, RoutedEventArgs e)
        {
            Face.LayoutTransform = new ScaleTransform(-1, 1);
        }
    }
}
