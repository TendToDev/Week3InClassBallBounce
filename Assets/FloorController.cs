using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FloorController : MonoBehaviour
{

    public int ballCounter;
    // Start is called before the first frame update
    Text gameOverTxt;

    void Start()
    {
        gameOverTxt = GameObject.Find("GameOverMsg").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump")) {
            // make it a toggle using if/else
            // hint check if timeScale is zero
            if(Time.timeScale == 0) {
                Time.timeScale = 1;    
                SceneManager.LoadScene(0);
                gameOverTxt.text = ".";
            }
        }
    }

    //Called when my gameObject collides with another
    //Requires at least 1 of the gameObjects to have a Rigidbody.
    private void OnTriggerEnter(Collider other) {
        // A ball just fell through me (the floor)
        ballCounter--;
        if(ballCounter <= 0) {
            // Pause game
            Time.timeScale = 0;
            gameOverTxt.text = "Game Over\nSpace to Restart";
        }
    }
}
