using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{

    public ParticleSystem shimmerParticles;
    public float speed;
    public GameObject mirrorObj;
    public Rigidbody2D particleRb;
    public Vector3 velocity;
    public bool shimmer,stop;

    // Start is called before the first frame update
    void Start()
    {
        mirrorObj = GameObject.FindGameObjectWithTag("BrokenMirror");

        particleRb = shimmerParticles.GetComponent<Rigidbody2D>();

        shimmerParticles.Stop();
        shimmerParticles.GetComponent<Renderer>().enabled = false;

        stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (shimmer)
        {           
            StartCoroutine(ParticleEffects());
            
            particleRb.MovePosition(velocity);
        }

        if (stop)
        {
            StopAllCoroutines();
            stop = true;
        }

    }

   public IEnumerator ParticleEffects()
    {
        velocity = Vector3.MoveTowards(shimmerParticles.transform.position, mirrorObj.transform.position, speed * Time.deltaTime);

        if (shimmerParticles.transform.position == mirrorObj.transform.position) {
            mirrorObj.GetComponent<Mirror>().FixMirror();

            yield return new WaitForSeconds(5);
            shimmerParticles.Stop();
            shimmerParticles.GetComponent<Renderer>().enabled = false;
            stop = true;
        }
    }
}
