using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
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
using System.Drawing;
using System.Windows.Interop;
using System.Drawing.Imaging;
using Emgu.CV.Reg;
using System.Windows.Forms;
using Emgu.CV.CvEnum;
using DataLayer.saveImageSource;
using MessageBox = System.Windows.Forms.MessageBox;

namespace ImagesProcessing.Edit
{
    /// <summary>
    /// Interaction logic for EditPage.xaml
    /// </summary>
    public partial class EditPage : Window
    {
        private string imagePath;

        private Bitmap GetBitmapFromMainImageBox()
        {
            var imageSource = mainImageBox.Source as BitmapSource;

            if (imageSource == null)
                return null;

            using (var memoryStream = new MemoryStream())
            {
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(imageSource));
                encoder.Save(memoryStream);
                return new Bitmap(memoryStream);
            }
        }

        private Bitmap GetBitmapFromImageBox()
        {
            var imageSource = imageBox.Source as BitmapSource;

            if (imageSource == null)
                return null;

            using (var memoryStream = new MemoryStream())
            {
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(imageSource));
                encoder.Save(memoryStream);
                return new Bitmap(memoryStream);
            }
        }

        private BitmapImage ToBitmapImage(Image<Bgr, byte> image)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                image.ToBitmap().Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }

        private bool doSharpenning(double range)
        {
            try
            {
                Bitmap bitmap = GetBitmapFromImageBox();
                Image<Bgr, byte> image = bitmap.ToImage<Bgr, byte>();
                var gaussianSmooth = image.SmoothGaussian(9);
                var mask = image - gaussianSmooth;
                image += mask * range;
                imageBox.Source = ToBitmapImage(image);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool doContrast(double range)
        {
            try
            {
                Bitmap bitmap = GetBitmapFromImageBox();
                Image<Bgr, byte> img1 = bitmap.ToImage<Bgr, byte>();
                Mat mat = img1.Mat;
                Mat newMat = new Mat();
                CvInvoke.ConvertScaleAbs(mat, newMat, range, 0);
                Image<Bgr, byte> img = newMat.ToImage<Bgr, byte>();
                using (MemoryStream memory = new MemoryStream())
                {
                    img.ToBitmap().Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                    memory.Position = 0;
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = memory;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();
                    imageBox.Source = bitmapImage;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool doBrightness(double range)
        {
            try
            {
                Bitmap bitmap1 = GetBitmapFromMainImageBox();
                Image<Bgr, byte> image = bitmap1.ToImage<Bgr, byte>();
                image = image.Mul(range);
                Bitmap bitmap = image.ToBitmap();
                IntPtr hBitmap = bitmap.GetHbitmap();
                ImageSource wpfBitmap = Imaging.CreateBitmapSourceFromHBitmap(
                    hBitmap,
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
                imageBox.Source = wpfBitmap;
                return true;
            }
            catch
            {
                return false;
            }

        }


        private void loadAndConfigPage()
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath, UriKind.Absolute);
            bitmap.EndInit();
            imageBox.Source = bitmap;
            mainImageBox.Source = bitmap;
        }

        public EditPage(string _imagePath)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            imagePath = _imagePath;
            loadAndConfigPage();
        }

        private void CreateImageBtn_Click(object sender, RoutedEventArgs e)
        {
            doBrightness(briSlider.Value);
            doContrast(conSlider.Value);
            doSharpenning(sharpSlider.Value);
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            using (saveImageSources db = new saveImageSources((BitmapSource)imageBox.Source))
            {
                if(db.isImageSaved())
                    MessageBox.Show("Image added successfully", "Information", (MessageBoxButtons)MessageBoxButton.OK, (MessageBoxIcon)MessageBoxImage.Information);
                this.Close();
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
