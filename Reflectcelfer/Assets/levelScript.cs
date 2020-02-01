using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelScript : MonoBehaviour
{ 
    public int level;
    public GameObject player,respA;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newLevel()
    {
        level++;
        if (level == 2)
        {
            transform.position = new Vector3();
            player.transform.position = new Vector3();
            respA.transform.position = new Vector3();
        }
        else if (level == 3)
        {
            transform.position = new Vector3();
            player.transform.position = new Vector3();
            respA.transform.position = new Vector3();
        }
        else if (level == 4)
        {
            transform.position = new Vector3();
            player.transform.position = new Vector3();
            respA.transform.position = new Vector3();
        }
        else if (level == 5)
        {
            transform.position = new Vector3();
            player.transform.position = new Vector3();
            respA.transform.position = new Vector3();
        }
        else if (level == 6)
        
        {
            transform.position = new Vector3();
            player.transform.position = new Vector3();
            respA.transform.position = new Vector3();
        }


    }
}
