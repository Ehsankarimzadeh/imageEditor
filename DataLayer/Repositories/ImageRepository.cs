using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class ImageRepository : IImageRepository
    {
        ImagesProcessing_DBEntities db;

        public ImageRepository(ImagesProcessing_DBEntities _db)
        {
            this.db = _db;
        }

        public List<Images_DT> GetAll()
        {
            return db.Images_DT.ToList();

        }

        public bool Add(string image)
        {
            try
            {
                db.Images_DT.Add(new Images_DT() { ImagePath = image });
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
