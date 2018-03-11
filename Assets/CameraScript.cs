using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    private GameObject Disc;
    private Vector3 CamPos;
	// Use this for initialization
	void Start () {
        Disc = GameObject.Find("Disc");
        CamPos = new Vector3(Disc.transform.position.x, Disc.transform.position.y, -10.0f);
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.position = CamPos;
        CamPos = new Vector3(Disc.transform.position.x, Disc.transform.position.y, -10.0f);

    }
}
