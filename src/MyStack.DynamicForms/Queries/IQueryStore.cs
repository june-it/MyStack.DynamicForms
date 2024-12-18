namespace MyStack.DynamicForms.Queries
{
    public interface IQueryStore
    {
        Task<List<Query>?> GetListAsync(int skip, int take, string? keyword = null);
        Task<Query?> GetAsync(string name);
        Task<Query> InsertAsync(Query query);
        Task UpdateAsync(Query query);
        Task DeleteAsync(Query query);
    }
}
