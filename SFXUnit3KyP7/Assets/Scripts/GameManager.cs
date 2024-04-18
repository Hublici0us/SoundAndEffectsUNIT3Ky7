using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int score;
    public int scoreCounter = 1;

    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.gameOver == false)
        {
            score += scoreCounter;
            Debug.Log("Score :" + score);
        }
    }
}
