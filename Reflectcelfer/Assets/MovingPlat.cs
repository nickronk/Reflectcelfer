using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlat : MonoBehaviour
{
    bool goRight = true;
    public float multip;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(goRight);
        if (goRight)
            transform.position += (transform.right*multip);
        else
            transform.position -= (transform.right*multip);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Movers")
        { 
            bool opRo = goRight;
            goRight = !opRo;

        }
    }
}
