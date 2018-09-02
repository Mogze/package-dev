using Entitas;
using UnityEngine;
using zehreken.i_cheat;

public class GridTest : MonoBehaviour
{
	private Systems _systems;
	void Start()
	{
		_systems = new GridSystems(Contexts.sharedInstance);
		
		GridSquareUtils.CreateGrid(10, 10);
	}

	void Update()
	{
		_systems.Execute();
		_systems.Cleanup();
	}
}