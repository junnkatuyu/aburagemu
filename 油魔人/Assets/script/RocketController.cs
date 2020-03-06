using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RocketController : MonoBehaviour
{
    public GameObject bulletPrefab;
    bool isAttacking = false;
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
        if (Input.GetKeyDown(KeyCode.E) && this.isAttacking == false)
        {
            this.isAttacking = true;
            Invoke("AttackFalse", 2f);    // 2秒後にfalseに戻す関数を呼ぶ
            GameObject obj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            obj.transform.localScale = transform.localScale;

        }


    }
    void AttackFalse()
    {
        this.isAttacking = false;
    }
}