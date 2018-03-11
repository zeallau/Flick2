using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoveScript : MonoBehaviour {

    bool nextScene = false;


	// Use this for initialization
	void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
        CharControl();

    }

    //why it will keep calling Main Scene?
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Contact Enemy");
        

        //it should be only call once.
        if(nextScene == false)
        {
            SceneManager.LoadScene("Main", LoadSceneMode.Additive);
            nextScene = true;
        }


    }

    private void CharControl()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.gameObject.transform.Translate(0.0f, 0.5f, 0.0f);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.gameObject.transform.Translate(0.0f, -0.5f, 0.0f);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.gameObject.transform.Translate(-0.5f, 0.0f, 0.0f);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.gameObject.transform.Translate(0.5f, 0.0f, 0.0f);
        }

    }

}
