namespace Blueprint.DynamicForms.Fields
{
    public class HtmlField : FieldBase
    {
        public HtmlField(string name, string displayName, string? defaultValue, string? id = null)
            : base(name, displayName, FieldType.Html, id)
        {
            DefaultValue = defaultValue;
        }

        public string? DefaultValue { get; set; }
        public override object? GetDefaultValue() => DefaultValue;
    }
}
