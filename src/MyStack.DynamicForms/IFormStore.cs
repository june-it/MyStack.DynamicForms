namespace MyStack.DynamicForms
{
    public interface IFormStore
    {
        Task InsertAsync(Form form);
        Task UpdateAsync(Form form);
        Task DeleteAsync(Form form);
        Task DeleteAsync(string formName);
        Task<Form?> GetAsync(string formName);
    }
}
