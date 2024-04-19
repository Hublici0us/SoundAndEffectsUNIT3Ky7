using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private int score;
    public int scoreCounter = 20;

    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI endScoreUI;
    public TextMeshProUGUI restartUI;
    public RawImage gameOverScreen;

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
            scoreUI.SetText("Score : " + score);
        }

        if (playerController.gameOver == true)
        {
            gameOverScreen.gameObject.SetActive(true);
            endScoreUI.SetText("Score: " + score);
            scoreUI.gameObject.SetActive(false);

            if (Input.GetKeyDown(KeyCode.H))
            {
                SceneManager.LoadScene("Prototype 3");
            }
        }
    }
}
