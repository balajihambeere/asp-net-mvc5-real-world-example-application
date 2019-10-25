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
    public class GenreService : IGenreService
    {
        public int? Add(Genre entity)
        {
            using (DataContext context = new DataContext())
            {
                entity.CreatedOn = DateTime.Now;
                entity.CreatedBy = 1;
                context.Genre.Add(entity);
                Save(context);
                return entity.GenreID;
            }
        }

        public void Delete(Genre entity)
        {
            throw new NotImplementedException();
        }

        public int? Edit(Genre entity)
        {
            using (var context = new DataContext())
            {
                var originalEntity = context.Genre.Find(entity.GenreID);
                originalEntity.LastModifiedOn = DateTime.Now;
                originalEntity.LastModifieldBy = 1;
                context.Entry(originalEntity).CurrentValues.SetValues(entity);
                Save(context);
            }
            return entity.GenreID;
        }

        public Genre FindBy(Expression<Func<Genre, bool>> predicate)
        {
            return GetAll().AsQueryable().Where(predicate).FirstOrDefault();
        }

        public IEnumerable<Genre> GetAll()
        {
            using (DataContext context = new DataContext())
            {
                return context.Genre.AsQueryable<Genre>().ToList();
            }
        }

        private void Save(DataContext context)
        {
            context.SaveChanges();
        }
    }
}
