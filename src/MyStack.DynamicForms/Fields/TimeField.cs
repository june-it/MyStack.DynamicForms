namespace Blueprint.DynamicForms.Fields
{
    public class TimeField : FieldBase
    {
        public TimeField(string name, string displayName, TimeSpan? defaultValue, string? id = null) : base(name, displayName, FieldType.Time, id)
        {
            DefaultValue = defaultValue;
        }

        public TimeSpan? DefaultValue { get; set; }
        public override object? GetDefaultValue() => DefaultValue;
    }
}
