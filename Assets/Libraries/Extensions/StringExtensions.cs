using UnityEngine;

namespace zehreken.i_cheat.Extensions
{
	public static class StringExtensions
	{
		public static string Italic(this string s)
		{
			return $"<i>{s}</i>";
		}

		public static string Bold(this string s)
		{
			return $"<b>{s}</b>";
		}

		public static string Color(this string s, Color color)
		{
            var hexColor = ColorUtility.ToHtmlStringRGBA(color);
			return $"<color=#{hexColor}>{s}</color>";
		}

		public static string ToString<T>(T obj)
		{
			string s = "";
			var fields = typeof(T).GetFields();
			foreach (var fieldInfo in fields)
			{
				s += fieldInfo.Name + ": " + fieldInfo.GetValue(obj) + "\n";
			}

			return s;
		}
	}
}