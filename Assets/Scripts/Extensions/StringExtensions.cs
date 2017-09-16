namespace zehreken.i_cheat.Extensions
{
    public static class StringExtensions
    {
        public static string Italic(this string s)
        {
            return "<i>" + s + "</i>";
        }

        public static string Bold(this string s)
        {
            return "<b>" + s + "</b>";
        }
    }
}