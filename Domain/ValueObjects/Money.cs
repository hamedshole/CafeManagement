namespace Domain.ValueObjects
{
    public class Money(long value)
    {
        public long Value { get; set; } = value;

        public override string ToString()
        {
            return Value.ToString("#,#");
        }
    }
}
