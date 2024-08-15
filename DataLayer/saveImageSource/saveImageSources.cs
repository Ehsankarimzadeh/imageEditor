using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DataLayer.saveImageSource
{
    public class saveImageSources:IDisposable
    {
        BitmapSource bitmapSource;
        
        public saveImageSources(BitmapSource _bitmapSource)
        {
            bitmapSource = _bitmapSource;
        }

        private void saveImageOnDataBase(string image)
        {
            using (DataLayer.Context.DependencyInjection db = new DataLayer.Context.DependencyInjection())
            {
                db.GetImageRepository.Add(image);
                db.Save();
            }
        }

        public bool isImageSaved()
        {
            
            try
            {
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapSource));

                string imageName = Guid.NewGuid().ToString() + ".png";
                string imagePath = AppDomain.CurrentDomain.BaseDirectory + "/Images/";

                if (!Directory.Exists(imagePath))
                {
                    Directory.CreateDirectory(imagePath);
                }
                string imageInfo = imagePath + "\\" + imageName;

                using(var fstreaqm = new FileStream(imageInfo, FileMode.Create)){
                    encoder.Save(fstreaqm);
                }
                
                saveImageOnDataBase(imageInfo);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
        }
    }
}
