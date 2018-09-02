using System.Collections.Generic;

namespace zehreken.i_cheat
{
	public static class PathFinding
	{
		static PathFinding()
		{
		}

		public static void FindPathAStar(Dictionary<int, GridEntity> grid, GridEntity from, GridEntity to)
		{
//			var tilesToRemove = new List<int>();
//
//			Dbg.Log("Finding shortest path");
//			foreach (var pair in grid)
//			{
//				pair.Value.AddHCost(GetDistance(start, pair.Value));
//				pair.Value.AddGCost(0);
//			}
//
//			from.isFrontier = true;
//
//			while (GetFrontierEntities().Length != 0)
//			{
//				BoardEntity current = GetBestFrontier();
//
//				var neighbours = GetNeighbours(grid, current);
//
//				foreach (var neighbour in neighbours)
//				{
//					if (!neighbour.isVisited && !neighbour.isFrontier && !neighbour.hasBubbleId) // if entity has bubble that means it is an obstacle
//					{
//						neighbour.isFrontier = true;
//						neighbour.ReplaceGCost(current.gCost.value + 1);
//						neighbour.AddPathParent(current.boardPosition.coord3);
//					}
//				}
//
//				current.isFrontier = false;
//				current.isVisited = true;
//
//				if (current == finish)
//					break;
		}
	}
}