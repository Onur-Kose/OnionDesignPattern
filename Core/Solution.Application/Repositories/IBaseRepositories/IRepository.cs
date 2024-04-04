namespace Solution.Application.Repositories.IBaseRepository
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
