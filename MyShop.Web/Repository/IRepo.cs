using System.Linq.Expressions;

namespace MyShop.Web.Repository
{
    public interface IRepo<T>where T:class
    {
        public  T getById(int Id);
        public  IQueryable<T> getAll();
        public  T Create(T Entity);
        public  T Update(T Entity);
        public  void Delete(T Entity);
		public T FindInclude(Expression<Func<T, bool>> match, string[] Include = null);
		public IEnumerable<T> FindAllInclude(Expression<Func<T, bool>> match, string[] Include = null);
		public T FindIncludeLast(Expression<Func<T, bool>> match, string[] Include = null);
        public void DeleteAll(IEnumerable<T> Entity);
	}
}
