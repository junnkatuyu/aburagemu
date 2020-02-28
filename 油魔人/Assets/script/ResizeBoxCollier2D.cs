using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeBoxCollier2D : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            //コライダーのサイズをオブジェクトに合わせる
            Vector2 objectSize = gameObject.GetComponent<RectTransform>().sizeDelta;
            BoxCollider2D collider = GetComponent<BoxCollider2D>();
            collider.size = objectSize;
        }
    }
}