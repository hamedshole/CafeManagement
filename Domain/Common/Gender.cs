using System.Numerics;

namespace Domain.Common
{
    public record Gender(byte? Value)
    {
        public static Gender Male => new(2);
        public static Gender Female => new(1);
        public static Gender NotSpecified => new(0);

        
    }
}
