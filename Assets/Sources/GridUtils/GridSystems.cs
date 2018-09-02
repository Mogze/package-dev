namespace zehreken.i_cheat
{
	public class GridSystems : Feature
	{
		public GridSystems(Contexts contexts)
		{
			Add(new AddViewSystem(contexts.grid));
			Add(new GridPositionSystem(contexts.grid));
		}
	}
}