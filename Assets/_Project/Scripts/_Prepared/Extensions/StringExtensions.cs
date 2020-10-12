namespace _Project.Scripts.Extensions
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
        
        public static bool NotEmpty(this string str)
        {
            return !str.IsEmpty();
        }
    }
}