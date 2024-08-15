using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IImageRepository
    {
        List<Images_DT> GetAll();

        bool Add(string image);
    }
}
