namespace MyStack.DynamicForms.Fields
{
    public class BooleanField : FieldBase
    {
        public BooleanField(string name, string displayName, bool? defaultValue, string? id = null)
            : base(name, displayName, FieldType.Boolean, id)
        {
            DefaultValue = defaultValue;
        }
        public bool? DefaultValue { get; set; }
        public override object? GetDefaultValue() => DefaultValue;
        public override void TestValue(object? value)
        {
            if (Required)
            {
                if (value == null || !bool.TryParse(value.ToString(), out var _))
                    throw new InvalidCastException($"无法转换{value}为字段类型`{typeof(BooleanField).Name}`的有效值");
            }
            else
            {
                if (value != null && !bool.TryParse(value.ToString(), out var _))
                    throw new InvalidCastException($"无法转换{value}为字段类型`{typeof(BooleanField).Name}`的有效值");
            }
        }
    }
}
