using System.Runtime;
using UnityEngine;

namespace zehreken.i_cheat.Extensions
{
    public static class StringExtensions
    {
        public static string Italic(this string s)
        {
            return string.Format("<i>{0}</i>", s);
        }

        public static string Bold(this string s)
        {
            return string.Format("<b>{0}</b>", s);
        }

        public static string Color(this string s, Color color)
        {
            return string.Format("<color={0}>{1}</color>", color, s);
        }
        
        public static string ToString<T>(T obj)
        {
            // Write a function can convert any
            // object to string using reflection
            return obj.ToString();
        }
    }
}
