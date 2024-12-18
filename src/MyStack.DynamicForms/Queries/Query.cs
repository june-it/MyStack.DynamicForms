namespace MyStack.DynamicForms.Queries
{
    public class Query
    {
        public string Name { get; private set; } = default!;
        public string Value { get; private set; } = default!;
        private Query()
        {
        }
        public Query(string name, string value)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name), "名称不能为空");
            Name = name;
            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(value), "值不能为空");
            Value = value;
        }

    }
}
