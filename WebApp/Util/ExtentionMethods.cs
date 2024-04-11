namespace WebApp.Util
{
    public static class ExtentionMethods
    {

        public static int Push<T>(this T[] source, T value)
        {
            var index = Array.IndexOf(source, default(T));

            if (index != -1)
            {
                source[index] = value;
            }

            return index;
        }

    }
}
