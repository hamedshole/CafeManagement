namespace Shared.Model
{
    public class PriceLogModel
    {
        public long Value { get; set; }
        public DateOnly Start { get; set; }
        public DateOnly? End { get; set; }
    }
    public class MaterialPriceLogModel
    {
        public long BuyPrice { get; set; }
        public long SellPrice { get; set; }
        public DateOnly Start { get; set; }
        public DateOnly? End { get; set; }
    }
}
