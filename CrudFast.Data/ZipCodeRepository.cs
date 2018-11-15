using CrudFast.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CrudFast.Data
{
    public interface IZipCodeRepository : IDataRepository<ZipCode>
    {
        // add special fetches here
    }

    public class ZipCodeRepository : IDataRepository<ZipCode>, IZipCodeRepository
    {
        private CFContext dbContext = null;

        public ZipCodeRepository()
        {
            dbContext = new CFContext();
        }

        public IEnumerable<ZipCode> Get()
        {
            return dbContext.ZipCodeSet;
            //return dbContext.ZipCodeSet.Include("ZipCode").ToList();
        }

        public ZipCode Get(dynamic id)
        {
            return dbContext.ZipCodeSet.Find(id);
        }

        public ZipCode Add(ZipCode entity)
        {
            var newEntity = dbContext.ZipCodeSet.Add(entity);
            dbContext.SaveChanges();
            return newEntity;
        }

        public void Delete(dynamic id)
        {
            var delEntity = Get(id);

            if (delEntity != null)
            {
                dbContext.Entry<ZipCode>(delEntity).State = EntityState.Deleted;
                dbContext.SaveChanges();
            }
        }

        public void Delete(ZipCode entity)
        {
            Delete(entity.zipcodeid);
        }

        public ZipCode Update(ZipCode entity)
        {
            var updatedEntity = dbContext.ZipCodeSet.Attach(entity);
            dbContext.Entry<ZipCode>(entity).State = EntityState.Modified;

            updatedEntity.zipcodeid = entity.zipcodeid;
            updatedEntity.city = entity.city;
            updatedEntity.state = entity.state;
            updatedEntity.country = entity.country;
            updatedEntity.updated = entity.updated;
            updatedEntity.updatedby = entity.updatedby;
            dbContext.SaveChanges();

            return updatedEntity;
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
