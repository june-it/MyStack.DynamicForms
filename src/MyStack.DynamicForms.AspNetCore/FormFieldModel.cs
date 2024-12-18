using MyStack.DynamicForms.Fields;

namespace MyStack.DynamicForms.AspNetCore
{
    public class FormFieldModel
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string DisplayName { get; set; } = default!;
        public bool Required { get; set; }
        public bool Unique { get; set; }
        public bool Searchable { get; set; }
        public bool Listeable { get; set; }
        public FieldType FieldType { get; set; } 
        public ExtraPropertyDictionary? Properties { get; set; }
    }
}
