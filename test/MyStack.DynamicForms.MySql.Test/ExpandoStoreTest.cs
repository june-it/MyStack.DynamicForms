using System.Dynamic;
using Microsoft.Extensions.DependencyInjection;

namespace MyStack.DynamicForms.MySql.Test
{
    [TestClass]
    public sealed class ExpandoStoreTest : TestBase
    {
        [TestMethod]
        public async Task Insert()
        {
            var expandoStore = ServiceProvider!.GetRequiredService<IExpandoStore>();
            var expando = new ExpandoObject();
            expando.TryAdd("IsActive", true);
            expando.TryAdd("Birthday", DateTime.Now);
            expando.TryAdd("Name", "Jun");
            await expandoStore.InsertAsync("Users", expando);
        }
        [TestMethod]
        public async Task Update()
        {
            var expandoStore = ServiceProvider!.GetRequiredService<IExpandoStore>();
            var expando = new ExpandoObject();
            expando.TryAdd("Id", 1);
            expando.TryAdd("IsActive", true);
            expando.TryAdd("Birthday", DateTime.Now);
            expando.TryAdd("Name", "Jun");
            await expandoStore.UpdateAsync("Users", expando);
        }
        [TestMethod]
        public async Task Get()
        {
            var expandoStore = ServiceProvider!.GetRequiredService<IExpandoStore>();
            var expando = await expandoStore.GetAsync("Users", 1);
        }

        [TestMethod]
        public async Task Delete()
        {
            var expandoStore = ServiceProvider!.GetRequiredService<IExpandoStore>();
            await expandoStore.DeleteAsync("Users", 1);
        }
    }
}
