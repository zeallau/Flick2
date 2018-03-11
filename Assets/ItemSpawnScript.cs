using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnScript : MonoBehaviour {

    

    public float StartSecond = 5.0f;
    public float EndSecond = 10.0f;
    float m_timer;


    private Vector3 ItemSpawnPos;
    private const float MOVE_SPEED_PER_SECOND = 2.0f;
    private Vector3 ItemMove = new Vector3(-1.0f, 0.0f, 0.0f);

    // Use this for initialization
    void Start () {
        

    }

    // Update is called once per frame
    void Update () {
        
        m_timer += Time.deltaTime;
        

        if (m_timer >= StartSecond && m_timer < EndSecond)
        {
            this.gameObject.transform.Translate(ItemMove * (MOVE_SPEED_PER_SECOND * Time.deltaTime));
            

        }
        if(m_timer > EndSecond)
        {
            m_timer = 0;
            this.gameObject.transform.position = ItemSpawnPos;
        }
        
    }

    

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Hit Soda");
    }
}
