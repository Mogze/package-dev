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

    private ServicesTester _servicesTester;

	void Start()
	{
		Dbg.Log("testing".Bold());
		Dbg.Log("testing".Italic());
		Dbg.Log("testing".Bold().Italic());
		Dbg.Log("testing".Italic().Bold());
		Dbg.Log("testing".Italic().Bold().Color(Color.red));

		Array = new int[10];
		Array.Fill(3);

        // MiniBus.SubscribeToEvent<TestMessage>(MiniBusTest);
        // MiniBus.SubscribeToEvent<TestMessage>(MiniBusTestTwo);

		GenericToStringTest();
		
		// _miniBusTests = new MiniBusTests(this);

        _servicesTester = new ServicesTester();
	}

	private void MiniBusTest(IMessage data)
	{
        var typed = (TestMessage) data;
		Dbg.Log($"first listener: {typed.TestInt}".Color(Color.gray));
	}

    private void MiniBusTestTwo(IMessage data)
    {
        var typed = (TestMessage) data;
        Dbg.Log($"second listener: {typed.TestInt}".Color(Color.yellow));
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
        MiniBus.PublishEvent<TestMessage>(new TestMessage(10));
		
		// _miniBusTests.Update();
	}

	public Elements GetElements()
	{
		return _elements;
	}

	private void OnDestroy()
	{
        MiniBus.UnsubscribeFromEvent<TestMessage>(MiniBusTest);
        MiniBus.UnsubscribeFromEvent<TestMessage>(MiniBusTestTwo);

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