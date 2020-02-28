using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RocketController : MonoBehaviour
{
    public GameObject bulletPrefab;

    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-0.1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0.1f, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject obj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            obj.transform.localScale = transform.localScale;

        }


    }

}