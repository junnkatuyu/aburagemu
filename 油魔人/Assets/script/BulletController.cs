using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
    void Update()
    {
        transform.Translate(0.2f * transform.localScale.x, 0, 0);

    }
    public float lifetime;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}