using DataLayer;
using DataLayer.Context;
using DataLayer.Repositories;
using Emgu.CV.Structure;
using Emgu.CV;
using ImagesProcessing.AddImage;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
using ImagesProcessing.Edit;
using ImagesProcessing.Histogram;
using ImagesProcessing.Crop;


namespace ImagesProcessing.Images
{
    /// <summary>
    /// Interaction logic for ImagesPage.xaml
    /// </summary>
    public partial class ImagesPage : Window
    {
        private string currentImagePath;
    
        public void loadImageGrid()
        {
            using (DependencyInjection db = new DependencyInjection())
            {
                imagesGrid.ItemsSource = db.GetImageRepository.GetAll();
            }
            imagesGrid.Columns[0].Visibility = Visibility.Hidden;
        }
        public ImagesPage()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            
        }

        private void loadImagesBtn_Click(object sender, RoutedEventArgs e)
        {
            loadImageGrid();
        }

        private void loadChosenImage(OpenFileDialog openImage)
        {
            AddImagePage addImage = new AddImagePage();
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(openImage.FileName);
            bitmap.EndInit();
            addImage.imageBox.Source = bitmap;
            addImage.ShowDialog();
            loadImageGrid();
        }

        private void addImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openImage = new OpenFileDialog();
            if (openImage.ShowDialog() == false)
                return;
            loadChosenImage(openImage);
        }

        private bool showImage()
        {
            if (currentImagePath == null)
                return false;

            try
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(currentImagePath, UriKind.Absolute);
                bitmap.EndInit();
                imageBox.Source = bitmap;
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void showNoPhotoIcon()
        {
            try
            {
                string imagePath = AppDomain.CurrentDomain.BaseDirectory + "/Images/";
                string noPhoto = imagePath + "\\" + "noPhoto.png";
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(noPhoto, UriKind.Absolute);
                bitmap.EndInit();
                imageBox.Source = bitmap;
            }
            catch
            {
                return;
            }
        }

        private void imagesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(imagesGrid.SelectedItem as Images_DT != null)
                currentImagePath = (imagesGrid.SelectedItem as Images_DT).ImagePath;
            if (!showImage())
                showNoPhotoIcon();
        }

        private void editImageBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!showImage())
            {
                MessageBox.Show("Please choose a picture (chosen picture may not exist)","Error",MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            EditPage editPage = new EditPage(currentImagePath);
            editPage.ShowDialog();
            loadImageGrid();
        }

        private void imageHistogramBtn_Click(object sender, RoutedEventArgs e)
        {
            imageHistogramPage histogramPage = new imageHistogramPage(currentImagePath);
            histogramPage.ShowDialog();
        }

        private void cropImageBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!showImage())
            {
                MessageBox.Show("Please choose a picture (chosen picture may not exist)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            cropPage cropPage = new cropPage(currentImagePath);
            cropPage.ShowDialog();
            loadImageGrid();
        }
    }
}
