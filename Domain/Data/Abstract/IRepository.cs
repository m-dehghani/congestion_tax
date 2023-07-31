using Domain.Entities.Abstract;

namespace Infrastructure.Data.Abstract
{
    public interface IRepository
    {
        public abstract static Entity? Get(string key);
    }
}
