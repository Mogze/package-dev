using UnityEngine;
using zehreken.i_cheat.Extensions;

public class Main : MonoBehaviour
{
    public int[] array;
    void Start()
    {
        Debug.Log("testing".Bold());
        Debug.Log("testing".Italic());
        Debug.Log("testing".Bold().Italic());
        Debug.Log("testing".Italic().Bold());

        array = new int[10];
        array.Fill(3);
    }

    void Update()
    {
    }
}