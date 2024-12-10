using Blueprint.DynamicForms;
using Microsoft.Extensions.DependencyInjection;

namespace Blueprint.DynamicForms.MySql.Test
{
    [TestClass]
    public sealed class MySqlFormRepositoryTest : TestBase
    { 
        [TestMethod]
        public async Task Insert()
        {
            var formRepository = ServiceProvider!.GetRequiredService<IFormRepository>();
            var form = new FormBuilder()
                .New("Users", "用户")
                .SetBooleanField("IsActive", "是否激活", false, "95e63cdb-e44a-4685-9fc3-db53efa83b13")
                .SetDateField("Birthday", "生日", true, null, "dbdd076d-eeae-4513-b0a2-e540e362a6bf")
                .SetDateTimeField("JoinIn2", "加入时间", true, null, "30b0cabf-93e8-4f9f-893d-bc36c02d9de2")
                .SetFileField("Attach", "个人档案", new[] { "text/plain" }, 100, null)
                .SetHtmlField("Intro", "个人档案", null)
                .SetImageField("Avatar", "个人档案", false, new[] { "image/png" }, 100, null)
                .SetLinkField("Website", "个人网站", "_blank", null)
                .SetMarkdownField("Intro2", "个人档案", null)
                .SetMultiTextField("Intro3", "个人档案", null)
                .SetNumericField("Height", "身高", 2, null)
                .SetTextField("IDCard", "身份证号码", 20, null, unique: true)
                .SetTextField("Name", "姓名", 10, "", required: true, unique: true)
                .Build();

            await formRepository.InsertAsync(form);
        }
        [TestMethod]
        public async Task Update()
        {
            var formRepository = ServiceProvider!.GetRequiredService<IFormRepository>();
            var form = new FormBuilder()
                .New("Users", "用户")
                .SetBooleanField("IsActive", "是否激活", false, "95e63cdb-e44a-4685-9fc3-db53efa83b13")
                .SetDateField("Birthday", "生日", true, null, "dbdd076d-eeae-4513-b0a2-e540e362a6bf")
                .SetDateTimeField("JoinIn2", "加入时间", true, null, "30b0cabf-93e8-4f9f-893d-bc36c02d9de2")
                .SetFileField("Attach", "个人档案", new[] { "text/plain" }, 100, null)
                .SetHtmlField("Intro", "个人档案", null)
                .SetImageField("Avatar", "个人档案", false, new[] { "image/png" }, 100, null)
                .SetLinkField("Website", "个人网站", "_blank", null)
                .SetMarkdownField("Intro2", "个人档案", null)
                .SetMultiTextField("Intro3", "个人档案", null)
                .SetNumericField("Height", "身高", 2, null)
                .SetTextField("IDCard", "身份证号码", 20, null, unique: true)
                .SetTextField("Name", "姓名", 10, "", required: true, unique: true)
                .Build();

            await formRepository.UpdateAsync(form);
        }
        [TestMethod]
        public async Task Delete()
        {
            var definitionService = ServiceProvider!.GetRequiredService<IFormRepository>();
            await definitionService.DeleteAsync("Users");
        }
    }
}
