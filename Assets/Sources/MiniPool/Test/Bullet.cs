using UnityEngine;
using zehreken.i_cheat.MiniPool;

public class Bullet : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * 10f * Time.deltaTime);
        if (transform.localPosition.y > 10f)
        {
            gameObject.SendToPool();
        }
    }
}