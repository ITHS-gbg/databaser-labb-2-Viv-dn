namespace Labb2_DbFirst_Template.Interfaces;

public interface IRepository<TEntity, in TIsbn13>
    where TEntity : IEntity<TIsbn13>
{
    TEntity GetById(TIsbn13 id);
    IEnumerable<TEntity> GetAll();
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TIsbn13 id);

}