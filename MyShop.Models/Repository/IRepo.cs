namespace MyShop.Web.Repository
{
    public interface IRepo<T>where T:class
    {
        public  Task<T> getById(int Id);
        public  Task<IQueryable<T>> getAll();
        public  Task<T> Create(T Entity);
        public  Task<T> Update(T Entity);
        public  void Delete(T Entity);
    }
}
