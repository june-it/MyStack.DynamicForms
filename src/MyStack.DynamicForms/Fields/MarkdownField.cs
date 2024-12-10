namespace Blueprint.DynamicForms.Fields
{
    public class MarkdownField : FieldBase
    {
        public MarkdownField(string name, string displayName, string? defaultValue, string? id = null)
            : base(name, displayName, FieldType.Markdown, id)
        {
            DefaultValue = defaultValue;
        }

        public string? DefaultValue { get; set; }
        public override object? GetDefaultValue() => DefaultValue;
    }
}
