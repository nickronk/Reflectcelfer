using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roto : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.rotation = new Quaternion(transform.rotation.x + .5f, transform.rotation.y, transform.rotation.z, transform.rotation.w);
    }
}
