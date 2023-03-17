namespace Mogze.Extensions
{
	public static class ArrayExtenions
	{
		public static T[] Fill<T>(this T[] a, T element)
		{
			for (int i = 0; i < a.Length; i++)
			{
				a[i] = element;
			}

			return a;
		}
	}
}