using Domain.Entities.Abstract;

namespace Infrastructure.Data.Abstract
{
    public interface IRepository
    {
        public abstract static Entity? Get(string key);
        public void Update(Entity entity);
        public void Delete(string key);
        public IEnumerable<Entity> GetAll();
        public void Create(Entity entity);

    }
}
