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
    public class LanguageService : ILanguageService
    {
        public int? Add(Language entity)
        {
            using (var context = new DataContext())
            {
                entity.CreatedOn = DateTime.Now;
                entity.CreatedBy = 1;
                context.Language.Add(entity);
                Save(context);
                return entity.LanguageID;
            }
        }

        public void Delete(Language entity)
        {
            throw new NotImplementedException();
        }

        public int? Edit(Language entity)
        {
            using (var context = new DataContext())
            {
                var originalEntity = context.Language.Find(entity.LanguageID);
                originalEntity.LastModifiedOn = DateTime.Now;
                originalEntity.LastModifieldBy = 1;
                context.Entry(originalEntity).CurrentValues.SetValues(entity);
                Save(context);
            }
            return entity.LanguageID;
        }

        public Language FindBy(Expression<Func<Language, bool>> predicate)
        {
            return GetAll().AsQueryable().Where(predicate).FirstOrDefault();
        }

        public IEnumerable<Language> GetAll()
        {
            using (var context = new DataContext())
            {
                return context.Language.AsQueryable<Language>().ToList();
            }
        }
        private void Save(DataContext context)
        {
            context.SaveChanges();
        }
    }
}
