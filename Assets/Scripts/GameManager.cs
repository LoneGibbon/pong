using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody2D paddleLeftRB;
    public Rigidbody2D paddleRightRB;

    public GameObject gameOverScreen;
    public GameObject gameElements;

    public GameObject startScreen;

    public BallController ballController;

    // Update is called once per frame
    void Update()
    {
        float moveLeft = Input.GetAxis("RacketLeft") * moveSpeed;
        float moveRight = Input.GetAxis("RacketRight") * moveSpeed;

        // Debug.Log("Move left: " + moveLeft);
        // Debug.Log("Move right: " + moveRight);

        paddleLeftRB.velocity = new Vector2(0, moveLeft);
        paddleRightRB.velocity = new Vector2(0, moveRight);
    }

    public void StartGame(){
        if(startScreen.activeInHierarchy)
            startScreen.SetActive(false);

        if(!gameElements.activeInHierarchy)
            gameElements.SetActive(true);

        ballController.ballRB.velocity = new Vector2(1, 1) * 500;
    }

    public void GameOver(string player){
        if(gameElements.activeInHierarchy)
            gameElements.SetActive(false);

        if(!gameOverScreen.activeInHierarchy) 
            gameOverScreen.SetActive(true);

        gameOverScreen.transform.GetChild(1).GetComponent<Text>().text = "Player " + player + " wins"; 
    }

    public void RestartGame(){
        SceneManager.LoadScene(0);
    }
}
