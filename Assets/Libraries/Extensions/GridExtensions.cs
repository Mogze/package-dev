﻿namespace zehreken.i_cheat.Extensions
{
	public class GridExtensions
	{
		public static T[,] CreateGrid<T>(int rowCount, int columnCount)
		{
			return new T[rowCount, columnCount];
		}
	}
}