using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D ballRB;

    public GameManager gameManager;

    private void OnCollisionEnter2D(Collision2D collision){
        //Debug.Log("The ball hit the gameobject: " + collision.gameObject);

        GameObject go = collision.gameObject;

        if(go.name == "Paddle Left"){
            ballRB.velocity *= 1.1f;
        }
        if(go.name =="Paddle Right"){
            ballRB.velocity *= 1.1f;
        }
        if(go.name =="Left"){
            //Right player wins
            gameManager.GameOver("Right");
        }
        if(go.name == "Right"){
            //Left player wins
            gameManager.GameOver("Left");
        }

        GetComponent<AudioSource>().Play();
    }
}
