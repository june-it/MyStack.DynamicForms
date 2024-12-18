namespace MyStack.DynamicForms.Fields
{
    public class FieldBase
    {
        private FieldBase()
        {

        }
        protected FieldBase(string name, string displayName, FieldType fieldType, string? id = null)
        {
            if (string.IsNullOrEmpty(id))
                id = Guid.NewGuid().ToString();
            Id = id;
            Name = name;
            DisplayName = displayName;
            FieldType = fieldType;
        }
        // 唯一id，用于区分同名字段是<删除再增加>还是<修改> 
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string DisplayName { get; set; } = default!;
        public bool Required { get; set; }
        public bool Unique { get; set; } 
        public FieldType FieldType { get; private set; }
        public virtual object? GetDefaultValue() => null;

        public virtual void Valid()
        {
            if (Required)
            {
                if (GetDefaultValue() == null)
                    throw new ArgumentNullException(nameof(GetDefaultValue), "必填时默认值不能为空");
            }
        }
        public virtual void TestValue(object? value)
        {
        }
    }
}
