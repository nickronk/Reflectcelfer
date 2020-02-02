using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pulseColor : MonoBehaviour
{

   
    SpriteRenderer spriterer;
    bool up;
    public float colores = 111;

    void Start()
    {
        up = false;
        spriterer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (up)
        {
            colores++;
        }
        else
        {
            colores--;

        }

        spriterer.color = new Color(111f, 111f, 111f);
        
        if (colores<10)
        {
            up = true;
        }
        if (colores>245)
        {
            up = false;
        }
    }
}
