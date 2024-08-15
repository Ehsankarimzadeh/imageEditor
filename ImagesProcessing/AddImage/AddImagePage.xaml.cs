using DataLayer;
using DataLayer.Context;
using DataLayer.Repositories;
using DataLayer.saveImageSource;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.IO.Pipes;
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
using static System.Net.Mime.MediaTypeNames;

namespace ImagesProcessing.AddImage
{
    /// <summary>
    /// Interaction logic for AddImagePage.xaml
    /// </summary>
    public partial class AddImagePage : Window
    {
        public AddImagePage()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            saveImageSources db = new saveImageSources((BitmapSource)imageBox.Source);
            if (db.isImageSaved())
                MessageBox.Show("Image added successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("Image not added", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            this.Close();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
