namespace Solution.Application.Repositories.IBaseRepository
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Asenkron olarak bir veriyi veri tabanına ekler 
        /// </summary>
        /// <param name="model"></param>
        /// <returns>async bool </returns>
        Task<bool> AddAsync(T model);
        /// <summary>
        /// Asenkron olarak bir veri Listesini veri tabanına ekler 
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        Task<bool> AddRangeAsync(List<T> datas);
        /// <summary>
        /// bir veriyi veri tabanıdna günceller
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(T model);
        bool UpdateRange(IEnumerable<T> model);
        /// <summary>
        /// modeli veri tabanındankaldırır
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Remove(T model);
        /// <summary>
        /// bir veri setini veri tabanından kaldırır
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        bool RemoveRange(List<T> datas);
        /// <summary>
        /// Id ye bağlı veriyi siler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> RemoveAsync(string id);
        /// <summary>
        /// Id ye bağlı veriyi siler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> RemoveAsync(Guid id);
        /// <summary>
        /// güncellenen, silinen veya eklenen verileri veri tabnında düzenler
        /// </summary>
        /// <returns>yapılan değişiklik sayısını asenkron olarak döner</returns>
        Task<int> SaveAsync();
    }
}
