using System.ComponentModel.DataAnnotations;

namespace MyStack.DynamicForms.AspNetCore
{
    public class CreateOrUpdateFormModel
    {
        [Required]
        public string Name { get; set; } = default!;
        public string DisplayName { get; set; } = default!;

        public List<FormFieldModel>? Fields { get; set; }
    }
}
