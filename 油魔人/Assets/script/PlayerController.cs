using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{

    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 400.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 3.0f;

    float temperture = 50f;    // 温度
    [SerializeField]
    float lowerTempureturePerSecond = 1f;    // 1秒間に下げる温度
    float upperTempureturePerSecond = 25f;    // 1秒間に上げる温度
    float upperTempureturePerSecons = 5f;

    bool isFinished = false;
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (this.isFinished == true)
        {
            return;
        }

        // 温度を下げる
        LowerTemperture();


        // ジャンプする
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button1)) && this.rigid2D.velocity.y == 0)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        // 左右移動
        float key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;
        if (key == 0)
        {
            key = Input.GetAxis("Horizontal");
        }


        // プレイヤの速度
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        // スピード制限
        this.rigid2D.AddForce(transform.right * key * this.walkForce);
        if (speedx >= this.maxWalkSpeed)
        {
            float pm = 1f;
            if (this.rigid2D.velocity.x < 0)
            {
                pm = -1f;
            }
            this.rigid2D.velocity = new Vector2(
                this.maxWalkSpeed * pm,
                this.rigid2D.velocity.y
                );

        }

        if (key != 0)
        {
            int idir = (int)transform.localScale.x;
            if (key > 0)
            {
                idir = 1;
            }
            else if (key < 0)
            {
                idir = -1;
            }
            float dir = Mathf.Clamp(idir, -1f, 1f);
            transform.localScale = new Vector3(dir, 1f, 1f);
        }


        // 画面外に出た場合は最初から
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }


    }


    /// <summary>
    /// 温度を下げる
    /// </summary>
    void LowerTemperture()
    {
        if (this.temperture > 0)
        {
            this.temperture -= this.lowerTempureturePerSecond * Time.deltaTime;
            this.temperture = Mathf.Clamp(this.temperture, 0, 100);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // ホットゾーンなら
        if (collision.gameObject.tag == "Hot")
        {
            if (this.temperture < 100)
            {
                this.temperture += this.upperTempureturePerSecond * Time.deltaTime;
                this.temperture = Mathf.Clamp(this.temperture, 0, 100);
            }
        }
        if (collision.gameObject.tag == "Ice")
        {
            if (this.temperture < 100)
            {
                this.temperture -= this.upperTempureturePerSecons * Time.deltaTime;
                this.temperture = Mathf.Clamp(this.temperture, 0, 100);
            }
        }
    }
    public float Ondo()
    {
        return this.temperture;
    }
}