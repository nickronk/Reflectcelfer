using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{

    public SpriteRenderer brokenGlassSr;
    public SpriteRenderer glass;

    public Animator mirrorAnim;

    IEnumerator fixMirror()
    {
        mirrorAnim.SetTrigger("fixMirror");

        yield return new WaitForSeconds(1);        
    }
}
