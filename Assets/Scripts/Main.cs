using System.Collections.Generic;
using UnityEngine;
using zehreken.i_cheat.Extensions;
using zehreken.i_cheat.MiniBus;

public class Main : MonoBehaviour
{
    public int[] array;
    private int a = 0;
    void Start()
    {
        Debug.Log("testing".Bold());
        Debug.Log("testing".Italic());
        Debug.Log("testing".Bold().Italic());
        Debug.Log("testing".Italic().Bold());

        array = new int[10];
        array.Fill(3);
        
        MiniBus.SubscribeToEvent(GameEvent.TEST, MiniBusTest);
    }

    private void MiniBusTest(Dictionary<string, object> data)
    {
        Debug.Log(data["test"].ToString().Bold());
    }

    void Update()
    {
        MiniBus.PublishEvent(GameEvent.TEST, new Dictionary<string, object> {{"test", a++}});
    }

    private void OnDestroy()
    {
        MiniBus.UnsubscribeFromEvent(GameEvent.TEST, MiniBusTest);
    }
}