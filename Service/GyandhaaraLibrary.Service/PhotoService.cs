using GyandhaaraLibrary.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GyandhaaraLibrary.DataModel;
using System.Linq.Expressions;
using GyandhaaraLibrary.Data;

namespace GyandhaaraLibrary.Service
{
    public class PhotoService : IPhotoService
    {
        public int? Add(Photo entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Photo entity)
        {
            throw new NotImplementedException();
        }

        public int? Edit(Photo entity)
        {
            throw new NotImplementedException();
        }

        public Photo FindBy(Expression<Func<Photo, bool>> predicate)
        {
            using (var context = new DataContext())
            {
                return context.Photo.AsQueryable().Where(predicate).SingleOrDefault();
            }
        }

        public IEnumerable<Photo> GetAll()
        {
            using (var context = new DataContext())
            {
                return context.Photo.AsQueryable().ToList();
            }
        }
    }
}
