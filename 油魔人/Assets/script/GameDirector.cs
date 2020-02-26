using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // UI部品を使うために必要！

public class GameDirector : MonoBehaviour
{
    PlayerController HOT;

    GameObject 油魔人;
    GameObject ホットゾーン;
    GameObject Text;

    void Start()
    {
        this.油魔人 = GameObject.Find("油魔人");
        this.HOT = this.油魔人.GetComponent<PlayerController>();
        this.ホットゾーン = GameObject.Find("ホットゾーン");
        this.Text = GameObject.Find("Text");
    }

    void Update()
    {
        /*
                if (this.ホットゾーン == null)
                {
                    Debug.Log("ホットゾーン");
                }
                if (this.油魔人 == null)
                {
                    Debug.Log("油魔人");
                }
        */
        this.Text.GetComponent<Text>().text = "　" + this.HOT.Ondo().ToString("F2") + "c°";
    }
}