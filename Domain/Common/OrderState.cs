namespace Domain.Common
{
    public record OrderState(byte Value)
    {
        public static OrderState InQeue => new(0);

        public static OrderState Cancelled=>new(1);
        public static OrderState InProgress => new(2);
        public static OrderState Delivered => new(3);


    }
}
