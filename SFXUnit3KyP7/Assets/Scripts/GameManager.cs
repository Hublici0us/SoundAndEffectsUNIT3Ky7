using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int score;
    public int scoreCounter = 20;

    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        if (playerController.gameOver == false)
        {
            score = score + scoreCounter;
            Debug.Log("Score :" + score);
        }
    }
}
