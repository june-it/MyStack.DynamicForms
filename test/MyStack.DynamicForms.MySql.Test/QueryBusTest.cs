using Microsoft.Extensions.DependencyInjection;
using MyStack.DynamicForms.Queries;

namespace MyStack.DynamicForms.MySql.Test
{
    [TestClass]
    public class QueryBusTest : TestBase
    {
        [TestMethod]
        public async Task QueryList()
        {
            var queryBus = ServiceProvider!.GetRequiredService<IQueryBus>();
            var items = await queryBus.QueryAsync("GetUsers", 0, 10);
        }
        [TestMethod]
        public async Task QueryById()
        {
            var queryHandler = ServiceProvider!.GetRequiredService<ISqlQueryHandler>();
            var items = await queryHandler.HandleAsync(new SqlQuery("SELECT * FROM Users WHERE Id=@Id;")
            {
                Parameters = new Dictionary<string, object> {
                    {
                        "Id",1
                    }
                }
            });
        }
    }
}
