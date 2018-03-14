using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Each : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
        
    }

    // Update is called once per frame
    void Update () {
        if(Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Debug.Log("BeganPos is " + Input.GetTouch(0).position);
            }
            /*
            if(Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Debug.Log("MovedPos is " + Input.GetTouch(0).position);
            }
            */
            if(Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                Debug.Log("EndedPos is " + Input.GetTouch(0).position);
            }
        }
        
    }
}
