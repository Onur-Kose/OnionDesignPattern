namespace Solution.Application.Repositories.IBaseRepository
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Bir veri tipindeki tüm delete olmayan verileri döner
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll(bool tracking = true);
        /// <summary>
        /// Bir veri tipindeki tüm delete olmayan verileri asenkron döner
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync(bool tracking = true);
        /// <summary>
        /// Şartı sağlayan tüm değerlei döner
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
        /// <summary>
        /// Şartı sağlayan tek bir değer döner
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        Task<T?> GetSingleAsync(Expression<Func<T, bool>> method);
        /// <summary>
        /// Id si girilen veriyi asnkron döner eğer veri silinmişse veya yoksa null döner
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T?> GetByIdAsync(Guid id);
        /// <summary>
        /// Id si girilen veriyi asnkron döner eğer veri silinmişse veya yoksa null döner
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T?> GetByIdAsync(string id);
        /// <summary>
        /// bir veririn olup olmadığını kontrol eden method
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>veri varsa ture yoksa false döenr</returns>
        bool HasEntity(Guid Id);
        /// <summary>
        /// bir veririn olup olmadığını kontrol eden method
        /// </summary>
        /// <param name="method"></param>
        /// <returns>veri varsa ture yoksa false döenr</returns>
        bool HasEntity(Expression<Func<T, bool>> method);
        /// <summary>
        /// bir veririn olup olmadığını kontrol eden async method
        /// </summary>
        /// <param name="method"></param>
        /// <returns>veri varsa ture yoksa false döenr</returns>
        Task<bool> HasEntityAsync(Expression<Func<T, bool>> method);
        /// <summary>
        /// bir veririn olup olmadığını kontrol eden async method
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>veri varsa ture yoksa false döenr</returns>
        Task<bool> HasEntityAsync(Guid Id);
        /// <summary>
        /// Silinmiş verileri getirir
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAllDeleted();
        /// <summary>
        /// Veri tipindeki delete olmayan veri sayısını döner
        /// </summary>
        /// <returns></returns>
        Task<int> GetCountAsync(bool tarcking = true);
        /// <summary>
        /// Veri tipindeki delete olmayan veri sayısını döner
        /// </summary>
        /// <returns></returns>
        Task<int> GetCountAsync(Expression<Func<T, bool>> predicate, bool tarcking = true);
    }
}
