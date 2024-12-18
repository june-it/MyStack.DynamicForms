using System.Dynamic;

namespace MyStack.DynamicForms
{
    public interface IExpandoStore
    {
        Task InsertAsync(string formName, ExpandoObject expando);
        Task UpdateAsync(string formName, ExpandoObject expando);
        Task DeleteAsync(string formName, int id);
        Task<ExpandoObject?> GetAsync(string formName, int id);
    }
}
