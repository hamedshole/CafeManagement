namespace Domain.ValueObjects
{
    public class Amount
    {

        public  long Value;

        public Amount(long value)
        {
            Value = value;
        }
        public Amount()
        {
            
        }
        public override string ToString()
        {
            return Value.ToString("#,#");
        }
        
    }
   
}