using UnityEngine;
using UnityEditor;

public class MakeScriptableObject
{
	[MenuItem("Mogze/Create/PrefabDictionary")]
	public static void CreatePrefabDictionary()
	{
		PrefabDictionary asset = ScriptableObject.CreateInstance<PrefabDictionary>();

		AssetDatabase.CreateAsset(asset, "Assets/Resources/PrefabDictionary.asset");
		AssetDatabase.SaveAssets();

		EditorUtility.FocusProjectWindow();

		Selection.activeObject = asset;
	}
}
