using Fluent.Infrastructure.FluentModel;
using Microsoft.EntityFrameworkCore;
using MyShop.Web.Repository;
using MyShop.Web.Models;

namespace MyShop.Web.Repository
{
    public class Repo<T>:IRepo<T> where T :class
    {
        private readonly ApplicationDbContext context;
        public Repo(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<T> getById(int Id)
        {
            return await context.Set<T>(). FindAsync(Id);
        }
        public async Task<IQueryable<T>> getAll()
        {
            IQueryable <T> Entity=  context.Set<T>();
            return Entity;
        }
        public async Task<T> Create(T Entity)
        {
            context.Set<T>().Add(Entity);
            context.SaveChangesAsync();
            return Entity;
        }
        public async Task<T> Update(T Entity)
        {
            //context.Set<T>().Update(Entity);
            context.SaveChangesAsync();
            return Entity;
        }
        public async void Delete(T Entity)
        {
            context.Set<T>().Remove(Entity);
            context.SaveChangesAsync();
        }
    }
}
