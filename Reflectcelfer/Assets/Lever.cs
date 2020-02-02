using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{

    public ParticleSystem shimmerParticles;
    public float speed;
    public GameObject mirrorObj;
    public Rigidbody2D particleRb;
    public AudioSource shimmerSound;
    public AudioClip[] leverSounds;
    public Vector3 velocity;
    public bool shimmer,stop,playFix;
    public levelScript levScript;
    public SpriteRenderer blackBox;

    // Start is called before the first frame update
    void Start()
    {

        //mirrorObj = GameObject.Find("BrokenMirror" + levScript.level.ToString());

        for (int a = 0; a < mirrorObj.transform.childCount; a++)
        {
            mirrorObj.transform.GetChild(a).gameObject.SetActive(false);
        }

        particleRb = shimmerParticles.GetComponent<Rigidbody2D>();
        shimmerSound = GetComponent<AudioSource>();

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

            if (shimmerSound.isPlaying == false)
            {
                shimmerSound.clip = leverSounds[1];
                shimmerSound.Play();
            }


            particleRb.MovePosition(velocity);
        }

        if (playFix)
        {
            shimmerSound.clip = leverSounds[2];
            shimmerSound.Play();
        }

        if (stop)
        {
            StopAllCoroutines();
            stop = true;
            shimmerSound.Stop();

            for (int a = 0; a < mirrorObj.transform.childCount; a++)
            {
                mirrorObj.transform.GetChild(a).gameObject.SetActive(true);
            }
            blackBox.enabled = true;

        }
    }

   public IEnumerator ParticleEffects()
    {
        velocity = Vector3.MoveTowards(shimmerParticles.transform.position, mirrorObj.transform.position, speed * Time.deltaTime);

        if (shimmerParticles.transform.position == mirrorObj.transform.position) {
            mirrorObj.GetComponent<Mirror>().FixMirror();
            shimmerParticles.Stop();
            //playFix = true;

            yield return new WaitForSeconds(3);

            shimmerParticles.GetComponent<Renderer>().enabled = false;
            stop = true;
        }
    }
}
