namespace MyStack.DynamicForms.Fields
{
    public class DateTimeField : FieldBase
    {
        public DateTimeField(string name, string displayName, bool useNowAsDefaultValue, DateTime? defaultValue, string? id = null)
            : base(name, displayName, FieldType.DateTime, id)
        {
            UseNowAsDefaultValue = useNowAsDefaultValue;
            DefaultValue = defaultValue;
        }
        public bool UseNowAsDefaultValue { get; set; }
        public DateTime? DefaultValue { get; set; }
        public override object? GetDefaultValue() => DefaultValue;
    }
}
