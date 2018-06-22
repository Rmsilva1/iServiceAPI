namespace iServiceApi.Services
{
    public interface IRepository<Tentity> where Tentity : class
    {
        System.Collections.Generic.IList<Tentity> GetAll();
        System.Collections.Generic.IList<Tentity> GetAll(System.Linq.Expressions.Expression<System.Func<Tentity, bool>> where);
        Tentity Get(object id);
        Tentity Insert(Tentity entity);
        bool Update(Tentity updated);
        bool Remove(Tentity remove);
        Tentity SaveChangesAsync();
        bool Exists(object id);
        System.Threading.Tasks.Task<bool> UpdateAsync(Tentity updated);
    }
}
