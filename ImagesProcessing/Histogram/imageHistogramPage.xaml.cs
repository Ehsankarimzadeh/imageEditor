using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;


namespace ImagesProcessing.Histogram
{
    /// <summary>
    /// Interaction logic for imageHistogramPage.xaml
    /// </summary>
    public partial class imageHistogramPage : Window
    {
        private string imagePath;

        private BitmapImage HistogramImageB { get; set; }
        private BitmapImage HistogramImageG { get; set; }
        private BitmapImage HistogramImageR { get; set; }


        public imageHistogramPage(string _imagePath)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            imagePath = _imagePath;
            drawHistogram();
        }
        private void drawHistogram()
        {
            
            Image<Bgr, byte> img = new Image<Bgr, byte>(imagePath);
            DenseHistogram histB = new DenseHistogram(256, new RangeF(0, 255));
            DenseHistogram histG = new DenseHistogram(256, new RangeF(0, 255));
            DenseHistogram histR = new DenseHistogram(256, new RangeF(0, 255));

            histB.Calculate(new Image<Gray, Byte>[] { img[0] }, true, null);
            histG.Calculate(new Image<Gray, Byte>[] { img[1] }, true, null);
            histR.Calculate(new Image<Gray, Byte>[] { img[2] }, true, null);

            float[] histogramValuesB = new float[256];
            float[] histogramValuesG = new float[256];
            float[] histogramValuesR = new float[256];

            histB.CopyTo(histogramValuesB);
            histG.CopyTo(histogramValuesG);
            histR.CopyTo(histogramValuesR);

            HistogramImageG = BitmapToImageSource(CreateHistogramBitmap(histogramValuesG, Color.Green));
            HistogramImageR = BitmapToImageSource(CreateHistogramBitmap(histogramValuesR, Color.Red));
            HistogramImageB = BitmapToImageSource(CreateHistogramBitmap(histogramValuesB, Color.Blue));
            Blue.Source=HistogramImageB; 
            Green.Source=HistogramImageG;
            Red.Source=HistogramImageR;
        }

        public Bitmap CreateHistogramBitmap(float[] values, Color color)
        {
            int width = 256;
            int height = 100;
            Bitmap bmp = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                for (int i = 0; i < values.Length; i++)
                {
                    int value = (int)(values[i] / values.Max() * height);
                    g.DrawLine(new Pen(color), i, height, i, height - value);
                }
            }

            return bmp;
        }

        public BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

