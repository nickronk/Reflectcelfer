using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorScript : MonoBehaviour
{
    SpriteRenderer sprRend;
    public GameObject otherM;
    float cooldownTimer;
    public float mainCooldown = 5;
    string ogTag;


    
    // Start is called before the first frame update
    void Start()
    {
        sprRend = GetComponent<SpriteRenderer>();
        ogTag = transform.tag;
        cooldownTimer = -1;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.tag);
        cooldownTimer = cooldownTimer - Time.deltaTime;

        if (cooldownTimer>0)
        {
            transform.tag = "None";
            sprRend.color = new Color(255, 0, 0);
        }
        else
        {
            transform.tag = ogTag;
            sprRend.color = new Color(0, 0, 255);
        }

        

    }

    private void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.transform.tag=="Player" && cooldownTimer<0)
        {
            //CooldownSet();
        }
    }

    public void CooldownSet()
    {
        otherM.GetComponent<mirrorScript>().CooldownSet2();
        CooldownSet2();
        
    }

    public void CooldownSet2()
    {
        cooldownTimer = mainCooldown;
    }
}
