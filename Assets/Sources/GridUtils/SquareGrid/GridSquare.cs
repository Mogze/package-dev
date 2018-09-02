using System.Collections.Generic;
using UnityEngine;

namespace zehreken.i_cheat
{
	public static class GridSquareUtils
	{
		private static Dictionary<int, GridEntity> _grid = new Dictionary<int, GridEntity>();

		static GridSquareUtils()
		{
		}

		public static Dictionary<int, GridEntity> CreateGrid(int rowCount, int columnCount)
		{
			var newGrid = new Dictionary<int, GridEntity>();
			for (int row = 0; row < rowCount; row++)
			{
				for (int column = 0; column < columnCount; column++)
				{
					var gridEntity = Contexts.sharedInstance.grid.CreateEntity();
					gridEntity.AddPrefab(Random.Range(0, 2) < 1 ? "Yellow" : "Green");
					gridEntity.AddCoord2(row, column);
					newGrid.Add(GetHash(row, column), gridEntity);
				}
			}

			return newGrid;
		}

		private static int GetHash(int row, int column)
		{
			return (row + column) * (row + column + 1) / 2 + column;
		}
	}
}