namespace MyStack.DynamicForms.Fields
{
    public class FileField : FieldBase
    {
        public FileField(string name, string displayName, string[]? mimeTypes, int maxFileSize, string? defaultValue, string? id = null)
            : base(name, displayName, FieldType.File, id)
        {
            MimeTypes = mimeTypes;
            MaxFileSize = maxFileSize;
            DefaultValue = defaultValue;
        }
        public string[]? MimeTypes { get; set; }
        // bytes
        public int MaxFileSize { get; set; }
        public string? DefaultValue { get; set; }
        public override object? GetDefaultValue() => DefaultValue;
    }
}
