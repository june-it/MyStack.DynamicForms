using Microsoft.Extensions.DependencyInjection;

namespace MyStack.DynamicForms.MySql.Test
{
    [TestClass]
    public sealed class MySqlFormStoreTest : TestBase
    {
        [TestMethod]
        public async Task Insert()
        {
            var formStore = ServiceProvider!.GetRequiredService<IFormStore>();
            var form = new FormBuilder()
                .New("Users", "User info")
                .SetBooleanField("IsActive", "Is active", false, "95e63cdb-e44a-4685-9fc3-db53efa83b13")
                .SetDateField("Birthday", "Birthday", true, null, "dbdd076d-eeae-4513-b0a2-e540e362a6bf")
                .SetDateTimeField("JoinIn2", "Joined date", true, null, "30b0cabf-93e8-4f9f-893d-bc36c02d9de2")
                .SetFileField("Attach", "Attach", new[] { "text/plain" }, 100, null)
                .SetHtmlField("Intro", "Intro", null)
                .SetImageField("Avatar", "Avatar", false, new[] { "image/png" }, 100, null)
                .SetLinkField("Website", "Personal website", "_blank", null)
                .SetMarkdownField("Intro2", "Intro2", null)
                .SetMultiTextField("Intro3", "Intro3", null)
                .SetNumericField("Height", "Height", 2, null)
                .SetTextField("IDCard", "ID card no", 20, null, unique: true)
                .SetTextField("Name", "Full name", 10, "", required: true, unique: true)
                .Build();

            await formStore.InsertAsync(form);
        }
        [TestMethod]
        public async Task Update()
        {
            var formStore = ServiceProvider!.GetRequiredService<IFormStore>();
            var form = new FormBuilder()
                .New("Users", "User info")
                .SetBooleanField("IsActive", "Is active", false, "95e63cdb-e44a-4685-9fc3-db53efa83b13")
                .SetDateField("Birthday", "Birthday", true, null, "dbdd076d-eeae-4513-b0a2-e540e362a6bf")
                .SetDateTimeField("JoinIn2", "Joined date", true, null, "30b0cabf-93e8-4f9f-893d-bc36c02d9de2")
                .SetFileField("Attach", "Attach", new[] { "text/plain" }, 100, null)
                .SetHtmlField("Intro", "Intro", null)
                .SetImageField("Avatar", "Avatar", false, new[] { "image/png" }, 100, null)
                .SetLinkField("Website", "Personal website", "_blank", null)
                .SetMarkdownField("Intro2", "Intro2", null)
                .SetMultiTextField("Intro3", "Intro3", null)
                .SetNumericField("Height", "Height", 2, null)
                .SetTextField("IDCard", "ID card no", 20, null, unique: true)
                .SetTextField("Name", "Full name", 10, "", required: true, unique: true)
                .Build();

            await formStore.UpdateAsync(form);
        }
        [TestMethod]
        public async Task Delete()
        {
            var formStore = ServiceProvider!.GetRequiredService<IFormStore>();
            await formStore.DeleteAsync("Users");
        }
    }
}
