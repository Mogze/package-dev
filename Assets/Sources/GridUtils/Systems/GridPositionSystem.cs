using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace zehreken.i_cheat
{
	public sealed class GridPositionSystem : ReactiveSystem<GridEntity>
	{
		public GridPositionSystem(IContext<GridEntity> context) : base(context)
		{
		}

		protected override ICollector<GridEntity> GetTrigger(IContext<GridEntity> context)
		{
			return context.CreateCollector(GridMatcher.Coord2.Added());
		}

		protected override bool Filter(GridEntity entity)
		{
			// Grid limits may be checked here
			return entity.hasView;
		}

		protected override void Execute(List<GridEntity> entities)
		{
			foreach (var gridEntity in entities)
			{
				var pos = new Vector3(GridConfig.ColumnOffset + GridConfig.TileWidth * gridEntity.coord2.column,
					GridConfig.RowOffset - GridConfig.TileHeight * gridEntity.coord2.row);
				gridEntity.view.value.transform.localPosition = pos;
			}
		}
	}
}