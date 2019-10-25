using GyandhaaraLibrary.Service.Interfaces;
using System;
using System.Linq;
using GyandhaaraLibrary.DataModel;
using System.Linq.Expressions;
using GyandhaaraLibrary.Data;
using System.Collections.Generic;
using System.Data.Entity;

namespace GyandhaaraLibrary.Service
{
    public class BookService : IBookService
    {
        public int? Add(Book entity)
        {
            using (var context = new DataContext())
            {
                entity.CreatedBy = 1;
                entity.CreatedOn = DateTime.Now;

                entity.Photo.CreatedBy = 1;
                entity.Photo.CreatedOn = DateTime.Now;

                context.Book.Add(entity);
                context.SaveChanges();
                return entity.BookID;
            }
        }

        public void Delete(Book entity)
        {
            throw new NotImplementedException();
        }

        public int? Edit(Book source)
        {
            using (var context = new DataContext())
            {
                var target = context.Book.AsQueryable().Where(x => x.BookID == source.BookID).FirstOrDefault();
                target.Code = source.Code;
                target.Title = source.Title;
                target.Isbn = source.Isbn;
                target.Edition = source.Edition;
                target.EntryDate = source.EntryDate;
                target.Publisher = source.Publisher;
                target.PublishDate = source.PublishDate;
                target.TotalPages = source.TotalPages;
                target.Author = source.Author;
                target.Price = source.Price;

                target.Photo = context.Photo.AsQueryable().Where(x => x.PhotoID == source.PhotoID).FirstOrDefault();
                target.Photo.Image = source.Photo.Image;
                target.Photo.FileName = source.Photo.FileName;
                context.Entry(target).State = EntityState.Modified;
                context.SaveChanges();
                return target.BookID;
            }
        }

        public Book FindBy(Expression<Func<Book, bool>> predicate)
        {
            return GetAll().AsQueryable().Where(predicate).SingleOrDefault();
        }

        public IEnumerable<Book> GetAll()
        {
            using (var context = new DataContext())
            {
                return context.Book.AsQueryable().ToList();
            }
        }
    }
}
