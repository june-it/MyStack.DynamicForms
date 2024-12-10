using System.Dynamic;
using Blueprint.DynamicForms;
using Microsoft.Extensions.DependencyInjection;

namespace Blueprint.DynamicForms.MySql.Test
{
    [TestClass]
    public sealed class ExpandoRepositoryTest : TestBase
    {
        [TestMethod]
        public async Task Insert()
        {
            var expandoRepository = ServiceProvider!.GetRequiredService<IExpandoRepository>();
            var expando = new ExpandoObject();
            expando.TryAdd("IsActive", true);
            expando.TryAdd("Birthday", DateTime.Now);
            expando.TryAdd("Name", "Jun");
            await expandoRepository.InsertAsync("Users", expando);
        }
        [TestMethod]
        public async Task Update()
        {
            var expandoRepository = ServiceProvider!.GetRequiredService<IExpandoRepository>();
            var expando = new ExpandoObject();
            expando.TryAdd("Id", 1);
            expando.TryAdd("IsActive", true);
            expando.TryAdd("Birthday", DateTime.Now);
            expando.TryAdd("Name", "Jun");
            await expandoRepository.UpdateAsync("Users", expando);
        }
        [TestMethod]
        public async Task Get()
        {
            var expandoRepository = ServiceProvider!.GetRequiredService<IExpandoRepository>();
            var expando = await expandoRepository.GetAsync("Users", 1);
        }

        [TestMethod]
        public async Task Delete()
        {
            var expandoRepository = ServiceProvider!.GetRequiredService<IExpandoRepository>();
             await expandoRepository.DeleteAsync("Users", 1);
        }
    }
}
