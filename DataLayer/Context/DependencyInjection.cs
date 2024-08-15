using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Context
{
    public class DependencyInjection : IDisposable
    {
        ImagesProcessing_DBEntities db = new ImagesProcessing_DBEntities();

        ImageRepository imageRepository;

        LoginRepository loginRepository;

        public LoginRepository GetLoginRepository
        {
            get
            {
                if (loginRepository == null)
                    loginRepository = new LoginRepository(db);
                return loginRepository;
            }
        }

        public ImageRepository GetImageRepository
        {
            get
            {
                if (imageRepository == null)
                    imageRepository = new ImageRepository(db);
                return imageRepository;
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
