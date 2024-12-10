namespace Blueprint.DynamicForms.Fields
{
    public class LinkField : FieldBase
    {
        public LinkField(string name, string displayName, string target, string? defaultValue, string? id = null)
            : base(name, displayName, FieldType.Link, id)
        {
            Target = target;
            DefaultValue = defaultValue;
        }

        public string? Target { get; set; }
        public string? DefaultValue { get; set; }
        public override object? GetDefaultValue() => DefaultValue;
    }
}
