using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.IO;
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
//using System.Windows;
//using System.Drawing;
using Point = System.Drawing.Point;
using DataLayer.saveImageSource;

namespace ImagesProcessing.Crop
{
    /// <summary>
    /// Interaction logic for cropPage.xaml
    /// </summary>
    public partial class cropPage : Window
    {
        string imagePath;
        int xMouseDown;
        int yMouseDown;
        int xMouseUp;
        int yMouseUp;
        int xMouseCurrent;
        int yMouseCurrent;
        bool isMouseDown = false;
            
        private void loadImage()
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath, UriKind.Absolute);
            bitmap.EndInit();
            imageBox.Source = bitmap;
            imageBox.Source = bitmap;
        }

        public cropPage(string _imagePath)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            imagePath = _imagePath;
            loadImage();
        }

        public void drawRectangleOnImage(string imagePath, System.Windows.Controls.Image imageControl)
        {
            Image<Bgr, byte> img = new Image<Bgr, byte>(imagePath);
            int width;
            int height;

            if (xMouseDown > xMouseCurrent)
                width = xMouseDown - xMouseCurrent;
            else
                width = xMouseCurrent - xMouseDown;
            if (yMouseDown > yMouseCurrent)
                height = yMouseDown - yMouseCurrent;
            else 
                height = yMouseCurrent - yMouseDown;

            int minXPosition;
            int minYPosition;

            if (xMouseDown > xMouseCurrent)
                minXPosition=xMouseCurrent;
            else
                minXPosition = xMouseDown;
            if (yMouseDown > yMouseCurrent)
                minYPosition = yMouseCurrent;
            else
                minYPosition = yMouseDown;

            
            
            var rect = new System.Drawing.Rectangle(minXPosition, minYPosition, width, height);
            
            img.Draw(rect, new Bgr(System.Drawing.Color.Black), 4);
            BitmapImage bitmapImage;
            using (MemoryStream memory = new MemoryStream())
            {
                img.ToBitmap().Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
            }
            imageControl.Source = bitmapImage;
        }

        private Point convertPositionTopixel(MouseEventArgs e)
        {
            var imageSource = imageBox.Source as BitmapSource;
            var position = Mouse.GetPosition(imageBox);
            var pixel = new Point();
            pixel.X = (int)(position.X * imageSource.PixelWidth / imageBox.ActualWidth);
            pixel.Y = (int)(position.Y * imageSource.PixelHeight / imageBox.ActualHeight);
            return pixel;
        }

        private void mouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            Point result = convertPositionTopixel(e);
            xMouseDown = (int)result.X;
            yMouseDown = (int)result.Y;
        }

        private void mouseMove(object sender, MouseEventArgs e)
        {
            if (!isMouseDown)
                return;
            Point result = convertPositionTopixel(e);
            xMouseCurrent = (int)result.X;
            yMouseCurrent = (int)result.Y;
            drawRectangleOnImage(imagePath, imageBox);
        }

        private void mouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            Point result = convertPositionTopixel(e);
            xMouseUp = (int)result.X;
            yMouseUp = (int)result.Y;
        }

        
        private void cropBtn_Click(object sender, RoutedEventArgs e)
        {
            int width=0;
            int height=0;

            if (xMouseDown > xMouseCurrent)
                width = xMouseDown - xMouseCurrent;
            else
                width = xMouseCurrent - xMouseDown;
            if (yMouseDown > yMouseCurrent)
                height = yMouseDown - yMouseCurrent;
            else
                height = yMouseCurrent - yMouseDown;

            int minXPosition = 0;
            int minYPosition = 0;

            if (xMouseDown > xMouseCurrent)
                minXPosition = xMouseCurrent;
            else
                minXPosition = xMouseDown;
            if (yMouseDown > yMouseCurrent)
                minYPosition = yMouseCurrent;
            else
                minYPosition = yMouseDown;

            Int32Rect cropRect = new Int32Rect(minXPosition, minYPosition, width, height);
            CroppedBitmap croppedBitmap = new CroppedBitmap((BitmapSource)imageBox.Source, cropRect);
            imageBox.Source = croppedBitmap;
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            saveImageSources db = new saveImageSources((BitmapSource)imageBox.Source);
            if (db.isImageSaved())
            {
                MessageBox.Show("Picture added successfully", "information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            this.Close();
        }
    }
}
