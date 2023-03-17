using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using zehreken.i_cheat;
using Mogze.Core.StringUtilities;
using Mogze.Core.MiniBus;
using Mogze.Audio;
using Mogze.MockData;
using System.Threading.Tasks;
using Mogze.Extensions;

public class Main : MonoBehaviour
{
    [SerializeField] private Elements _elements;
    public int[] Array;
    private int _a = 0;
    private MiniBusTests _miniBusTests;
    [SerializeField] private AudioDictionary _audioDictionary;

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

        _servicesTester = new ServicesTester(transform, _audioDictionary);

        TestAudio();
    }

    // async routines hide exceptions
    private async Task TestAudio()
    {
        await Task.Delay(1000);

        try
        {
            Mogze.Core.Services.Services.GetService<AudioService>().Play("beep");
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        Debug.Log("beep");
        await Task.Delay(1000);

        Mogze.Core.Services.Services.GetService<AudioService>().Play("beep");
        Debug.Log("beep");
        await Task.Delay(1000);

        Mogze.Core.Services.Services.GetService<AudioService>().Play("beep");
        Debug.Log("beep");
        await Task.Delay(1000);

        Mogze.Core.Services.Services.GetService<AudioService>().Play("beep");
        Debug.Log("beep");
        await Task.Delay(1000);

        Mogze.Core.Services.Services.GetService<AudioService>().Play("beep");
        Debug.Log("beep");
    }

    private void MiniBusTest(IMessage data)
    {
        var typed = (TestMessage)data;
        Dbg.Log($"first listener: {typed.TestInt}".Color(Color.gray));
    }

    private void MiniBusTestTwo(IMessage data)
    {
        var typed = (TestMessage)data;
        Dbg.Log($"second listener: {typed.TestInt}".Color(Color.yellow));
    }

    private void GenericToStringTest()
    {
        var testData = new TestData();
        testData.int_1 = 12;
        testData.string_1 = "twelve";
        testData.dict_1 = new Dictionary<string, string> { { "asd", "qwe" } };
        Debug.Log(testData.ToPrintable());
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