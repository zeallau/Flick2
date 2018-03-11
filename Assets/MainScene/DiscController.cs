using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DiscController : MonoBehaviour {

    //Click Down pos
    private Vector3 touchStartPos;
    private Vector3 touchStartworldPos;

    //Click Up Pos
    private Vector3 touchEndPos;
    private Vector3 touchEndworldPos;

    //clickDistance
    private Vector3 clickDistance;
    
    private float movedDistance = 0.0f;
    private const float MOVE_SPEED_PER_SECOND = 2.0f;

    private Vector3 discSpawnPos;

    private GameObject DiscText;
    private int disc = 5;

    // Use this for initialization
    void Start () {
        discSpawnPos = new Vector3(Random.Range(-2.6f, 2.6f), -4f, 0.0f);
        this.gameObject.transform.position = discSpawnPos;

        this.DiscText = GameObject.Find("DiscText");
    }
	
	// Update is called once per frame
	void Update () {
        Flick();

        if (movedDistance < clickDistance.magnitude)
        { 
          //moveDistance to count every secound the object move.
            float moveDistance = (clickDistance * (MOVE_SPEED_PER_SECOND * Time.deltaTime)).magnitude;
            this.gameObject.transform.Translate(clickDistance * (MOVE_SPEED_PER_SECOND * Time.deltaTime));
            movedDistance += moveDistance;
            //Debug.Log("moveDistance is" + moveDistance);
        }

        DiscRespawn();
    }

    //Flick to Move
    void Flick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            touchStartPos = new Vector3(Input.mousePosition.x,
                                        Input.mousePosition.y,
                                        Input.mousePosition.z);

            touchStartworldPos = Camera.main.ScreenToWorldPoint(touchStartPos);
            //Debug.Log("touchStarworldPos is" + touchStartworldPos);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {

            touchEndPos = new Vector3(Input.mousePosition.x,
                                      Input.mousePosition.y,
                                      Input.mousePosition.z);

            touchEndworldPos = Camera.main.ScreenToWorldPoint(touchEndPos);
            //Debug.Log("touchEndworldPos is" + touchEndworldPos);

            //Get click Distance
            clickDistance = (touchEndworldPos - touchStartworldPos) *2.5f;
            //Debug.Log("clickDistance is" + clickDistance.magnitude);

            movedDistance = 0.0f;
        }
        
    }

    void DiscRespawn()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Start();
            this.disc -= 1;
            this.DiscText.GetComponent<Text>().text = "Disc: " + disc + " / 5";
        }
    }
}
