using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public GameObject glass;

    public Animator mirrorAnim;

    void Start()
    {
        mirrorAnim = GetComponent<Animator>();
        glass = GameObject.FindGameObjectWithTag("FixedMirror");
        glass.gameObject.GetComponent<SpriteRenderer>().color = new Color32(255,255,255,0);
    }


    public void FixMirror()
    {
        mirrorAnim.SetTrigger("FixMirror");
    }
}
