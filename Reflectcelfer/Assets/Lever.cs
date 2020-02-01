using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{

    public ParticleSystem shimmerParticles;
    public float speed;
    public GameObject doorTrans;
    public Rigidbody2D particleRb;
    public Vector3 velocity;
    public bool shimmer;

    // Start is called before the first frame update
    void Start()
    {
        doorTrans = GameObject.FindGameObjectWithTag("Door");

        particleRb = shimmerParticles.GetComponent<Rigidbody2D>();

        shimmerParticles.Stop();
        shimmerParticles.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Bool" + shimmer);
        if (shimmer)
        {           
            StartCoroutine(ParticleEffects());
            
            particleRb.MovePosition(velocity);
        }

    }

   public IEnumerator ParticleEffects()
    {
        velocity = Vector3.MoveTowards(shimmerParticles.transform.position, doorTrans.transform.position, speed * Time.deltaTime);

        if (shimmerParticles.transform.position == doorTrans.transform.position) {

            yield return new WaitForSeconds(3);

            shimmerParticles.Stop();
            shimmerParticles.GetComponent<Renderer>().enabled = false;
        }
    }
}
