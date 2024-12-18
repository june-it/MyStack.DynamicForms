namespace MyStack.DynamicForms.Fields
{
    public class FieldProperty : Dictionary<string, object>
    {
        public TValue GetValue<TValue>(string key)
        {
            if (TryGetValue(key, out var value))
            {
                return (TValue)Convert.ChangeType(value, typeof(TValue));
            }
            return default!;
        }
    }
}
