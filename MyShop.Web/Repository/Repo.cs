using Microsoft.EntityFrameworkCore;
using MyShop.Web.Data;
using System.Linq.Expressions;

namespace MyShop.Web.Repository
{
    public class Repo<T>:IRepo<T> where T :class
    {
        private readonly ApplicationDbContext context;
        public Repo(ApplicationDbContext _context)
        {
            context = _context;
        }
        public T getById(int Id)
        {
            return  context.Set<T>().Find(Id);
        }
        public IQueryable<T> getAll()
        {
            IQueryable <T> Entity=  context.Set<T>();
            return Entity;
        }
        public T Create(T Entity)
        {
            context.Set<T>().Add(Entity);
            context.SaveChanges();
            return  Entity;
        }
        public T Update(T Entity)
        {
		    context.Set<T>().Update(Entity);
            context.SaveChanges();
            return Entity;
        }
        public async void Delete(T Entity)
        {
            context.Set<T>().Remove(Entity);
            context.SaveChanges();
        }
        public void DeleteAll(IEnumerable<T> Entity)
        {
            foreach (var item in Entity)
            {
                context.Set<T>().Remove(item);
            }
            context.SaveChanges();
        }
        public T FindInclude(Expression<Func<T, bool>> match, string[] Include = null)
        {
            IQueryable<T> obj = context.Set<T>();
            if (Include != null)
            {
                foreach (var item in Include)
                {
                    obj = obj.Include(item);
                }
            }
            return  obj.FirstOrDefault(match);
        }
        public T FindIncludeLast(Expression<Func<T, bool>> match, string[] Include = null)
        {
            IQueryable<T> obj = context.Set<T>();
            obj = obj.OrderDescending();
            if (Include != null)
            {
                foreach (var item in Include)
                {
                    obj = obj.Include(item);
                }
            }
             return  obj.FirstOrDefault(match);
        }
		public IEnumerable<T> FindAllInclude(Expression<Func<T, bool>> match, string[] Include = null)
		{
			IQueryable<T> obj = context.Set<T>();
			if (Include != null)
			{
				foreach (var item in Include)
				{
					obj = obj.Include(item);
				}
			}
			return  obj.Where(match).ToList();
		}
	}
}
