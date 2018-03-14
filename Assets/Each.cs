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
                Debug.Log("Touch Began");
            }
            if(Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Debug.Log("Touch Moved");
            }
            if(Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                Debug.Log("Touch Ended ");
            }
        }
        
    }
}
