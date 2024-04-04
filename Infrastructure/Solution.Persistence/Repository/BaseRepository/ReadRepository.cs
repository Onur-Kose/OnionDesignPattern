namespace Solution.Persistence.Repository.BaseRepository
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ThisAppDBCOntext _context;

        public ReadRepository(ThisAppDBCOntext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        ///Methodlaın içi doldurulacak 
        ///Örnek Kullanım
        ///************************************************
        ///public IQueryable<T> GetAll(bool tracking = true)
        ///
        ///    if (tracking)
        ///    {
        ///        return Table.Where(x => x.Status != Status.Deleted);
        ///    }
        ///    else
        ///    {
        ///        return Table.Where(x => x.Status != Status.Deleted).AsNoTracking();
        ///    }
        ///
        ///************************************************

        public IQueryable<T> GetAll(bool tracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync(bool tracking = true)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAllDeleted()
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountAsync(bool tarcking = true)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountAsync(Expression<Func<T, bool>> predicate, bool tarcking = true)
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetSingleAsync(Expression<Func<T, bool>> method)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            throw new NotImplementedException();
        }

        public bool HasEntity(Guid Id)
        {
            throw new NotImplementedException();
        }

        public bool HasEntity(Expression<Func<T, bool>> method)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasEntityAsync(Expression<Func<T, bool>> method)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasEntityAsync(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
