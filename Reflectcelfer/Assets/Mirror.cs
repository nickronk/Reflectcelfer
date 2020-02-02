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
    }


    public void FixMirror()
    {
        mirrorAnim.SetTrigger("FixMirror");
    }
}
