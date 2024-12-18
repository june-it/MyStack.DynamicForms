namespace MyStack.DynamicForms.Fields
{
    public class MultiTextField : FieldBase
    {
        public MultiTextField(string name, string displayName, string? defaultValue, string? id = null)
            : base(name, displayName, FieldType.MultiText, id)
        {
            DefaultValue = defaultValue;
        }
        public string? DefaultValue { get; set; }
        public override object? GetDefaultValue() => DefaultValue;
    }
}
