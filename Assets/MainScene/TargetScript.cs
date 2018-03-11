using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetScript : MonoBehaviour {

    private Vector3 targetSpawnPos;
    private float lastDTC;
    private float currentDTC;
    private float finalDTC;

    private GameObject disc;
    private float discToCenter;
    private float targetRadius;
    private float scoreYellow;
    private float scoreRed;
    private float scoreBlue;

    bool getDTC = false;
    bool scoring = false;
    bool scoreUp = false;

    private GameObject scoreText;
    private int score = 0;

    // Use this for initialization
    void Start () {
        disc = GameObject.Find("Disc");
        this.scoreText = GameObject.Find("ScoreText");


        targetSpawnPos = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(1.2f, 1.9f), 0.0f);
        this.gameObject.transform.position = targetSpawnPos;
        targetRadius = GetComponent<CircleCollider2D>().radius;
        
        scoreYellow = targetRadius * 0.162f;
        scoreRed = targetRadius * 0.5f;
        scoreBlue = targetRadius * 0.83f;

        getDTC = true;
        scoring = false;
        scoreUp = false;
    }

    // Update is called once per frame
    void Update () {
        Respawn();

    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        //Distance between Disc and center point of target
        discToCenter = Vector3.Distance(disc.transform.position, targetSpawnPos);
        

        //To compare currentDTC and lastDTC
        currentDTC = discToCenter;

        if (currentDTC == lastDTC && getDTC == true)
        {
            finalDTC = discToCenter;
            Debug.Log("finalDTC subposed is" + finalDTC);

            getDTC = false;
            scoring = true;
            scoreUp = true;
        }
        lastDTC = currentDTC;

        if(scoring == true)
        {
            if (finalDTC <= scoreYellow && scoreUp == true)
            {
                this.score += 100;
                this.scoreText.GetComponent<Text>().text = "Score: " + this.score + "pt";
                
                Debug.Log("+ 100 Score.");
                scoreUp = false;

            }
            else if (finalDTC > scoreYellow && finalDTC <= scoreRed && scoreUp == true)
            {
                this.score += 50;
                this.scoreText.GetComponent<Text>().text = "Score: " + this.score + "pt";

                Debug.Log("Get + 50 Score.");
                scoreUp = false;
            }
            else if (finalDTC > scoreRed && finalDTC <= scoreBlue && scoreUp == true)
            {
                this.score += 20;
                this.scoreText.GetComponent<Text>().text = "Score: " + this.score + "pt";
                Debug.Log(" + 20 Score.");
                scoreUp = false;
            }
            else if (finalDTC > scoreBlue && finalDTC <= targetRadius && scoreUp == true)
            {
                Debug.Log("Get + 0 Score. Missing");
                scoreUp = false;
            }
            if (getDTC)
            {
                getDTC = false;
            }
        }

    }

    void Respawn()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Start();
        }
    }
    

}
