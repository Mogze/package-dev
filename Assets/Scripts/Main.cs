using System.Collections.Generic;
using UnityEngine;
using zehreken.i_cheat;
using zehreken.i_cheat.Extensions;
using zehreken.i_cheat.MiniBus;
using zehreken.i_cheat.MockData;

public class Main : MonoBehaviour
{
    public int[] array;
    private int a = 0;

    void Start()
    {
        Dbg.Log("testing".Bold());
        Dbg.Log("testing".Italic());
        Dbg.Log("testing".Bold().Italic());
        Dbg.Log("testing".Italic().Bold());
        Dbg.Log("testing".Italic().Bold().Color(Color.red));

        array = new int[10];
        array.Fill(3);

        MiniBus.SubscribeToEvent(GameEvent.TEST, MiniBusTest);
        
        GenericToStringTest();
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
        StringExtensions.ToString(testData);
    }

    void Update()
    {
//        MiniBus.PublishEvent(GameEvent.TEST, new Dictionary<string, object> {{"test", a++}});
    }

    private void OnDestroy()
    {
        MiniBus.UnsubscribeFromEvent(GameEvent.TEST, MiniBusTest);
    }
}