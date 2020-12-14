using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    private int highscore = 0;
    public Text highscoreText;

    private void Start() {
        highscoreText.text = "Highscore : " + highscore;
    }

    private void Update() {
        highscoreText.text = "Highscore : " + highscore;
    }

    /// method ///

    public void SetHighScore(int score){
        if(score > highscore){
            highscore = score;
        }
    }  
}
