using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hensin : MonoBehaviour
{
    int hito = 1;
    int eki = 2;

    SpriteRenderer MainSpriteRenderer;
    // publicで宣言し、inspectorで設定可能にする
    public Sprite NomalSprite;
    public Sprite MomalSprite;

    void Start()
    {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))//Ｚが押されたら通常スライムになる
        {
            if (hito == 1)
            {
                MainSpriteRenderer.sprite = NomalSprite;//魔人の姿の更新
                hito =2;
                eki=1;
            }
            else
            {
                MainSpriteRenderer.sprite = MomalSprite;//魔人の姿の更新
                hito =1;
                eki=2;
            }

        }
    }
}