using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTrigger()
    {

        
        Debug.Log("Entered collision area");
        GameStageManager.Instance.OnCollision();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            GameStageManager.Instance.OnCollision();
        }
        else
        {

        }
    }
}
