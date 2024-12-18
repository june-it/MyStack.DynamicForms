using Microsoft.Extensions.DependencyInjection;
using MyStack.DynamicForms.Queries;

namespace MyStack.DynamicForms.MySql.Test
{
    [TestClass]
    public class QueryStoreTest : TestBase
    {
        [TestMethod]
        public async Task Query()
        {
            var queryStore = ServiceProvider!.GetRequiredService<IQueryStore>();
            var query = await queryStore.GetAsync("GetUsers");
        }
        [TestMethod]
        public async Task Insert()
        {
            var queryStore = ServiceProvider!.GetRequiredService<IQueryStore>();
            var query = await queryStore.InsertAsync(new Query("GetUsers", "SELECT * FROM Users;"));
        }
        [TestMethod]
        public async Task Update()
        {
            var queryStore = ServiceProvider!.GetRequiredService<IQueryStore>();
            await queryStore.UpdateAsync(new Query("GetUsers", "SELECT `Id`,`IsActive`,`Birthday`,`Name` FROM Users;"));
        }
    }
}
