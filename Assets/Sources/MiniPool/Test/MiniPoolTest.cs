using UnityEngine;
using zehreken.i_cheat.MiniPool;

public class MiniPoolTest : MonoBehaviour
{
    private float _timer = 0f;
    public float TimeLimit = 1f;

    void Start()
    {
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= TimeLimit)
        {
            MiniPool.Create((PrefabName)Random.Range(0, 2), new Vector3(Random.Range(-3, 3f), 0f, 0f));
            _timer = 0f;
        }
    }
}