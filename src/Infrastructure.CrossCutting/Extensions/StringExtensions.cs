namespace Infrastructure.CrossCutting.Extensions
{
    public static class StringExtensions
    {
        public static string Mask(this string source, int start, int maskLength)
        {
            var mask = new string('X', maskLength);

            var unMaskStart = source.Substring(0, start);

            var unMaskEnd = source.Substring(start + maskLength, source.Length - maskLength);

            return unMaskStart + mask + unMaskEnd;
        }
    }
}
