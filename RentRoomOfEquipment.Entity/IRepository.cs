using Microsoft.EntityFrameworkCore;
using RentRoomOfEquipment.Models.Base;

namespace RentRoomOfEquipment.Entity
{
    public class Repository<T> : IRepository<T>, IDisposable where T : BaseId<int>
    {
        private bool disposed = false;
        private ROEContext _context;
        public Repository(ROEContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", nameof(context));
            }

            _context = context;
            this.DbSet = this._context.Set<T>();
        }


        private DbSet<T> DbSet { get; }

        public List<T> GetAll()
        {
            return this.DbSet.ToList();
        }
        public T? GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Add(T entity)
        {
            this.DbSet.Add(entity);
            Save();
        }
        public void Update(T entity)
        {
            DbSet.Attach(entity);
            this._context.Entry(entity).State = EntityState.Modified;
        }
        public void Save()
        {
            this._context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

    }
    public interface IRepository<T> where T : BaseId<int>
    {
        List<T> GetAll();
        T? GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Save();
    }
}
