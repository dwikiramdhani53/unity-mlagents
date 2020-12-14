using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;

public class PlayerAgent : Agent
{
    public Spawner spawner;
    public EventController eventController;
    public Highscore highScore;

    private int score = 0;
    private Vector3 startPos;
    private Rigidbody rBody;

    private void Update() {
        if(transform.position.y < 0){
            AddReward(increment: -1.0f);
            highScore.SetHighScore(score);
            EndEpisode();
        }
        if(eventController.IsMiss()){
            AddReward(increment: -1.0f);
            highScore.SetHighScore(score);
            EndEpisode();
        }
    }

    private void FixedUpdate() {
        RequestDecision();
    }

    public override void Initialize(){
        startPos = transform.position;
    }

    public override void OnActionReceived(float[] vectorAction){
        if(Mathf.FloorToInt(vectorAction[0]) == 1){
            MoveLeft();
        }
        if(Mathf.FloorToInt(vectorAction[1]) == 1){
            MoveRight();
        }
    }   

    public override void OnEpisodeBegin(){
        // reset environtment
        Restart();
    }

    public override void Heuristic(float[] actionsOut){
        actionsOut[0] = 0;
        actionsOut[1] = 0;
        //player input
        if(Input.GetKey(KeyCode.LeftArrow)){
            MoveLeft();
            actionsOut[0] = 1;
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            MoveRight();
            actionsOut[1] = 1;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Item"){
            AddReward(increment: 1.0f);
            score += 1;
            Debug.Log("score : " + score);
            Destroy(other.gameObject);
        }
    }

    /// method ///
    private void MoveRight(){
        Vector3 position = transform.position;
        position.x += 0.1f;
        transform.position = position;
    }

    private void MoveLeft(){
        Vector3 position = transform.position;
        position.x -= 0.1f;
        transform.position = position;
    }

    public void Restart(){
        score = 0;
        eventController.ResetMiss();
        spawner.ClearItem();
        gameObject.transform.position = startPos;
    }
}
