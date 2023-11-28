namespace HotelBookingSystem.Interfaces
{
    public interface IRepository<TKey, TEntity>
    {
        TEntity GetById(TKey id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TKey id);
    }

}
