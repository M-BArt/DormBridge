namespace DormBridge.Domain.ValueObjects.Student
{
    public sealed class Phone
    {
        public string Value { get; set; }
        public Phone(string value)
        {
            Value = value;
        }

        public static implicit operator Phone(string value) => new(value);
        public static implicit operator string(Phone value) => value.Value;
        public override string ToString() => Value;
    }
}
