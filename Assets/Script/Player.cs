using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text scoreText;
    public float speed;
    private float maxRight;
    private float maxLeft;
    private int score = 0;
    private Vector3 startPos;

    private void Start() {
        maxRight = gameObject.transform.position.x + 3;
        maxLeft = gameObject.transform.position.x - 3;
        scoreText.text = "Score : " + score;
        startPos = gameObject.transform.position;
    }

    private void FixedUpdate() {
        Move();
    }

    public void AddScore(){
        score += 2;
    }

    public void MinusScore(){
        score -= 1;
    }

    private void Update() {
        scoreText.text = "Score : " + score;
    }

    private void Move(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float now = gameObject.transform.position.x + (moveHorizontal * speed);
        if(now <= maxRight && now >= maxLeft){
            gameObject.transform.position = new Vector3(now, gameObject.transform.position.y, gameObject.transform.position.z);
        }
    }

    public void Restart(){
        score = 0;
        GameObject[] obstacle;
        obstacle = GameObject.FindGameObjectsWithTag("Item");
        foreach (GameObject item in obstacle){
            Destroy(item);
        }
        gameObject.transform.position = startPos;
    }
}
