using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using zehreken.i_cheat;
using zehreken.i_cheat.Extensions;
using Mogze.Core.MiniBus;
using zehreken.i_cheat.MockData;

public class Main : MonoBehaviour
{
	[SerializeField] private Elements _elements;
	public int[] Array;
	private int _a = 0;
	private MiniBusTests _miniBusTests;

	void Start()
	{
		Dbg.Log("testing".Bold());
		Dbg.Log("testing".Italic());
		Dbg.Log("testing".Bold().Italic());
		Dbg.Log("testing".Italic().Bold());
		Dbg.Log("testing".Italic().Bold().Color(Color.red));

		Array = new int[10];
		Array.Fill(3);

		MiniBus.SubscribeToEvent(GameEvent.Test, MiniBusTest);

		GenericToStringTest();
		
		// _miniBusTests = new MiniBusTests(this);
	}

	private void MiniBusTest(Dictionary<string, object> data)
	{
		Dbg.Log(data["test"].ToString().Bold());
	}

	private void GenericToStringTest()
	{
		var testData = new TestData();
		testData.int_1 = 12;
		testData.string_1 = "twelve";
		testData.dict_1 = new Dictionary<string, string> {{"asd", "qwe"}};
		Debug.Log(StringExtensions.ToString(testData));
	}

	void Update()
	{
        MiniBus.PublishEvent(GameEvent.Test, new Dictionary<string, object> {{"test", _a++}});
		
		// _miniBusTests.Update();
	}

	public Elements GetElements()
	{
		return _elements;
	}

	private void OnDestroy()
	{
		MiniBus.UnsubscribeFromEvent(GameEvent.Test, MiniBusTest);

		_miniBusTests = null;
	}

	[Serializable]
	public struct Elements
	{
		public Text text;
		public Image image;
		public GameObject toggleObject;
		public Sprite Sprite1;
		public Sprite Sprite2;
	}
}