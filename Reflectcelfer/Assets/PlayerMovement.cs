using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D rb;
    public SpriteRenderer playerSr;
    //public Animator playerAnim;

    [Header("Movement")]
    public float speed;

    public bool mirrored = false;
    public Vector2 velocity;

    [Header("Jumping")]
    public float gravityUp;
    public float gravityDown;
    public float jumpVel;
    public bool onPlatform;

    [Header("Position")]
    public Vector2 startPos, playerPos;
    Vector2 rayDir = new Vector2(.5f, 0);
    GameObject mirror, normal;
   public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSr = GetComponent<SpriteRenderer>();
        //playerAnim = GetComponent<Animator>();

        startPos = transform.position;

        mirror = GameObject.FindGameObjectWithTag("Mirror");
        normal = GameObject.FindGameObjectWithTag("Normal");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //RAYCAST
        Vector2 rayStart = transform.position;
        RaycastHit hitInfo;
        Physics.Raycast(rayStart, rayDir, out hitInfo, 5);
        Debug.DrawRay(rayStart, rayDir * 5, Color.magenta);

        playerPos = transform.position;

        //MOVING
        if (mirrored == false)
        {
            playerSr.color = new Color32(255,146,146,255);
            velocity.x = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        }
        else if (mirrored == true)
        {
            playerSr.color = new Color32(146, 146, 255, 255);
            velocity.x = -Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        }

        // playerAnim.SetFloat("hInput", Mathf.Abs(velocity.x));

        if (velocity.x > 0)
        {
            playerSr.flipX = false;
            rayDir.x = Mathf.Abs(rayDir.x);
        }

        if (velocity.x < 0)
        {
            playerSr.flipX = true;
            rayDir *= -1;
        }

        if (onPlatform == false)
        {
            if (velocity.y > .5f)
            {
                velocity.y -= gravityUp * Time.deltaTime;
            }
            else
            {
                velocity.y -= gravityDown * Time.deltaTime;
            }
        }

        //JUMPING
        if (Input.GetButton("Jump"))
        {
            Debug.Log("IS JUMPING");

            if (onPlatform)
            {
                Debug.Log("CHECKING PLATFORM");
                velocity.y = jumpVel;
                //playerAnim.SetBool("Jump",true);
                onPlatform = false;
            }
        }

        //RIGIDBODY
        rb.MovePosition(rb.position + velocity);
        onPlatform = false;

    }//END OF UPDATE

    /*
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Mirror")
        {
            mirrored = true;
            transform.position = new Vector3(normal.transform.position.x,transform.position.y, normal.transform.position.z) - offset;
        }

        if (other.gameObject.tag == "Normal")
        {
            mirrored = false;
            transform.position =  new Vector3(normal.transform.position.x,transform.position.y, normal.transform.position.z) + offset;
        }
    }//END OF TRIGGER ENTER
    */

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            Debug.Log("ON PLATFORM");
            foreach (ContactPoint2D contact in other.contacts)
            {
                if (Mathf.Abs(contact.normal.y) > Mathf.Abs(contact.normal.x))
                {
                    velocity.y = 0;
                    if (contact.normal.y >= 0)
                    {
                        //playerAnim.SetBool("Jump", false);
                    }
                }
            }
        }//END OF PLATFORM COLLISION ENTER

        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Mirror")
        {
            Debug.Log("ON PLATFORM");
            foreach (ContactPoint2D contact in other.contacts)
            {
                if (Mathf.Abs(contact.normal.x) > Mathf.Abs(contact.normal.y))
                {
                    velocity.y = 0;
                    if (contact.normal.x >= 0)
                    {
                            mirrored = false;
                            transform.position = new Vector3(normal.transform.position.x, transform.position.y, normal.transform.position.z) - offset;
                    }
                }
            }
        }//END OF MIRROR

        if (other.gameObject.tag == "Normal")
        {
            Debug.Log("ON PLATFORM");
            foreach (ContactPoint2D contact in other.contacts)
            {
                if (Mathf.Abs(contact.normal.x) > Mathf.Abs(contact.normal.y))
                {
                    velocity.y = 0;
                    if (contact.normal.x <= 0)
                    {
                            mirrored = true;
                            transform.position = new Vector3(mirror.transform.position.x, transform.position.y, normal.transform.position.z) + offset;
                    }
                }
            }
        }//END OF NORMAL

    }//END ON COLLISISON ENTER

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            foreach (ContactPoint2D contact in other.contacts)
            {
                if (Mathf.Abs(contact.normal.y) > Mathf.Abs(contact.normal.x))
                {
                    if (contact.normal.y >= 0)
                    {
                        onPlatform = true;
                    }
                }
            }
        }//END OF PLATFORM COLLISION STAY
    }//END OF COLLSION STAY
}//END OF SCRIPT