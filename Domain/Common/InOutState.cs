using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;

namespace Domain.Common
{
    public record InOutState(bool Io)
    {
        public static InOutState TakeIn() => new(true);
        public static InOutState TakeOut() => new(false);

        public override string ToString()
        {
            string val = string.Empty;
            switch (Io)
            {
                case true:
                    val = "فروش";
                    break;
                case false:
                    val = "خرید";
                    break;
            }
            return val;
        }
    }
}
