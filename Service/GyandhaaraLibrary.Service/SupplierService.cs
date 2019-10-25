using GyandhaaraLibrary.Data;
using GyandhaaraLibrary.DataModel;
using GyandhaaraLibrary.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GyandhaaraLibrary.Service
{
    public class SupplierService : ISupplierService
    {
        public int? Add(Supplier entity)
        {
            using (var context = new DataContext())
            {
                //Add Address  related to the supplier
                AddOrUpdateAddress(entity.Address, context);
                context.Supplier.Add(entity);
                Save(context);
                return entity.SupplierID;
            }
        }

        public void Delete(Supplier entity)
        {
            throw new NotImplementedException();
        }

        public int? Edit(Supplier entity)
        {
            using (var context = new DataContext())
            {
                var target = context.Supplier.AsQueryable().Where(x => x.SupplierID == entity.SupplierID).FirstOrDefault();
                
                target.Name = entity.Name;
                target.Contact = entity.Contact;
                target.Email = entity.Email;
                target.LastModifiedOn = DateTime.Now;
                target.LastModifieldBy = 1;

                target.Address = context.Address.AsQueryable().Where(x => x.AddressID == target.AddressID).FirstOrDefault();
                target.Address.State = entity.Address.Street;
                target.Address.City = entity.Address.City;
                target.Address.State = entity.Address.State;
                target.Address.Country = entity.Address.Country;
                target.Address.ZipCode = entity.Address.ZipCode;
                target.Address.LastModifiedOn = DateTime.Now;
                target.Address.LastModifieldBy = 1;

                Save(context);
            }
            return entity.SupplierID;
        }

        public Supplier FindBy(Expression<Func<Supplier, bool>> predicate)
        {
            return GetAll().AsQueryable().Where(predicate).SingleOrDefault();
        }

        public IEnumerable<Supplier> GetAll()
        {
            using (var context = new DataContext())
            {
                return context.Supplier.AsQueryable().ToList();
            }
        }

        private void Save(DataContext context)
        {
            context.SaveChanges();
        }

        private int? AddOrUpdateAddress(Address entity, DataContext context)
        {
            if (entity.AddressID > 0)
            {
                var originalEntity = context.Address.Find(entity.AddressID);
                originalEntity.LastModifiedOn = DateTime.Now;
                originalEntity.LastModifieldBy = 1;
                context.Entry(originalEntity).CurrentValues.SetValues(entity);
            }
            else
            {
                entity.CreatedOn = DateTime.Now;
                entity.CreatedBy = 1;
                context.Address.Add(entity);
                Save(context);
            }
            return entity.AddressID;
        }

        public Supplier GetSupplierByID(int id)
        {
            using (var context = new DataContext())
            {
                var query = context.Supplier.AsQueryable().Where(x => x.SupplierID == id).FirstOrDefault();
                query.Address = context.Address.AsQueryable().Where(x => x.AddressID == query.AddressID).FirstOrDefault();
                return query;
            }
        }
    }
}
