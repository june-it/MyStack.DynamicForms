using System.Dynamic;

namespace Blueprint.DynamicForms
{
    public interface IExpandoRepository
    {
        Task InsertAsync(string formName, ExpandoObject expando);
        Task UpdateAsync(string formName, ExpandoObject expando);
        Task DeleteAsync(string formName,int id);
        Task<ExpandoObject?> GetAsync(string formName,int id);
    }
}
