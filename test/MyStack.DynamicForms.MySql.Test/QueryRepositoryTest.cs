using Blueprint.DynamicForms.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Blueprint.DynamicForms.MySql.Test
{
    [TestClass]
    public class QueryRepositoryTest : TestBase
    {
        [TestMethod]
        public async Task Query()
        {
            var queryRepository = ServiceProvider!.GetRequiredService<IQueryRepository>();
            var query = await queryRepository.GetAsync("GetUsers");
        }
        [TestMethod]
        public async Task Insert()
        {
            var queryRepository = ServiceProvider!.GetRequiredService<IQueryRepository>();
            var query = await queryRepository.InsertAsync(new Query("GetUsers", "SELECT * FROM Users;"));
        }
        [TestMethod]
        public async Task Update()
        {
            var queryRepository = ServiceProvider!.GetRequiredService<IQueryRepository>();
            await queryRepository.UpdateAsync(new Query("GetUsers", "SELECT `Id`,`IsActive`,`Birthday`,`Name` FROM Users;"));
        }
    }
}
