using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour
{

    public GameObject player;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);

        if (transform.position.x < 0)
        {
            transform.position = new Vector3(0, 0, -10);
        }
        if (transform.position.y < 0)
        {
            transform.position = new Vector3(transform.position.x, 0, -10);
        }
    }
}