namespace Blueprint.DynamicForms.Fields
{
    public class TextField : FieldBase, IStringField
    {
        public TextField(string name, string displayName, int maxLength, string? defaultValue, string? id = null)
            : base(name, displayName, FieldType.Text, id)
        {
            MaxLength = maxLength;
            DefaultValue = defaultValue;
        }
        public int MaxLength { get; set; }
        public string? DefaultValue { get; set; }
        public override object? GetDefaultValue() => DefaultValue;
    }
}
