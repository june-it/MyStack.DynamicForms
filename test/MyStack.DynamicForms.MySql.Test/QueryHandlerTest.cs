using Blueprint.DynamicForms.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Blueprint.DynamicForms.MySql.Test
{
    [TestClass]
    public class QueryHandlerTest : TestBase
    {
        [TestMethod]
        public async Task Query()
        {
            var queryHandler = ServiceProvider!.GetRequiredService<ISqlQueryHandler>();
            var items = await queryHandler.HandleAsync(new SqlQuery("SELECT * FROM Users;"));
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
