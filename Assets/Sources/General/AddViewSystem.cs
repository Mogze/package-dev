using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Object = UnityEngine.Object;

namespace zehreken.i_cheat
{
	public sealed class AddViewSystem : ReactiveSystem<GridEntity>, ITearDownSystem
	{
		private readonly Transform _gameContainer;

		public AddViewSystem(IContext<GridEntity> context) : base(context)
		{
			_gameContainer = new GameObject("GameContainer").transform;
		}

		protected override ICollector<GridEntity> GetTrigger(IContext<GridEntity> context)
		{
			return context.CreateCollector(GridMatcher.Prefab);
		}

		protected override bool Filter(GridEntity entity)
		{
			return true;
		}

		protected override void Execute(List<GridEntity> entities)
		{
			foreach (var gameEntity in entities)
			{
				gameEntity.AddView(MiniPool.Create((PrefabName) Enum.Parse(typeof(PrefabName), gameEntity.prefab.value), Vector3.zero));
				gameEntity.view.value.transform.SetParent(_gameContainer);
			}
		}

		public void TearDown()
		{
			Object.Destroy(_gameContainer.gameObject);
		}
	}
}