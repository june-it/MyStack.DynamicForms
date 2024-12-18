using MyStack.DynamicForms.Fields;

namespace MyStack.DynamicForms
{
    public class Form
    {
        public string Name { get; set; } = default!;
        public string DisplayName { get; set; } = default!;
        public List<FieldBase>? Fields { get; set; }
        public ExtraPropertyDictionary ExtraProperties { get; set; }
        protected Form()
        {
            ExtraProperties = new ExtraPropertyDictionary();
        }
        public Form(string name, string displayName)
            : this()
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name), "名称不能为空");
            Name = name;
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(displayName), "显示名称不能为空");
            DisplayName = displayName;
        }
    }
}
