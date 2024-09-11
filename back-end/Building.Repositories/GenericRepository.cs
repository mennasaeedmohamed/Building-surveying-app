using Building.Repositories;
using Building.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Building.Context.Context;

namespace Building.Repositories
{

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        BuildingDbContext buildingDbContext;
        DbSet<T> dbset;
        public GenericRepository(BuildingDbContext _buildingDbContext)
        {
            buildingDbContext = _buildingDbContext;
            dbset = buildingDbContext.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return dbset;
        }
        public IQueryable<T> GetOne(int id)
        {
            return dbset;
        }
        public void Create(T Entity)
        {
            dbset.Add(Entity);
            buildingDbContext.SaveChanges();

        }
        public void Update(T Entity)
        {
            dbset.Update(Entity);
            buildingDbContext.SaveChanges();

        }
        public void Delete(T Entity)
        {
            dbset.Remove(Entity);
            buildingDbContext.SaveChanges();

        }

    }

}
