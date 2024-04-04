
namespace Solution.Persistence.Repository.BaseRepository
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly ThisAppDBCOntext _context;

        public WriteRepository(ThisAppDBCOntext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        ///Metodlar düzenlenecek ve doldurulacak <summary>
        ///Örenk Kullanımım
        ///**********************************************
        ///        public async Task<bool> AddAsync(T model)
        ///{
        ///    EntityEntry<T> entityEntry = await _table.AddAsync(model);
        ///    return entityEntry.State == EntityState.Added;
        ///}
        ///************************************************
    public Task<bool> AddAsync(T model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddRangeAsync(List<T> datas)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRange(List<T> datas)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public bool Update(T model)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRange(IEnumerable<T> model)
        {
            throw new NotImplementedException();
        }
    }
}
