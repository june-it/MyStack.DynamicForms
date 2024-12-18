using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace MyStack.DynamicForms.MySql.DynamicForms
{
    public abstract class FormStoreBase
    {
        protected string Prefix = "Forms_";
        public FormStoreBase(IOptions<MySqlOptions> options)
        {
            ConnectionString = options.Value.ConnectionString;
        }
        protected string ConnectionString { get; }
        protected virtual string GetFormName(string formName) => $"{Prefix}{formName}";
        protected virtual async Task<Form?> GetOrDefaultAsync(MySqlConnection connection, string formName)
        {
            var command = connection.CreateCommand();
            command.CommandText = $"SELECT `Value`  FROM `Forms` WHERE `Name`='{GetFormName(formName)}'";
            var result = await command.ExecuteScalarAsync();
            if (result == null)
                return null;
            var value = Convert.ToString(result);
            if (string.IsNullOrEmpty(value))
                return null;
            return JsonConvert.DeserializeObject<Form>(value);
        }
    }
}
