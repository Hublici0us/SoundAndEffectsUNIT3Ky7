using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30;
    public float speedAdd = 20;
    private float timeMod = 2;
    private float leftBoundary = -15;
    PlayerController playerControl;

    // Start is called before the first frame update
    void Start()
    {
        playerControl = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControl.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBoundary && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

        if (Input.GetKey(KeyCode.F))
        {
            Time.timeScale = timeMod;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
