using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D rb;
    public SpriteRenderer enemySr;
    //public Animator enemyAnim;

    [Header("Movement")]
    public float speed;
    public Vector2 velocity;

    [Header("Position")]
    public Vector2 startPos, enemyPos;
    public GameObject findPlayer;
    Vector2 rayDir = new Vector2(.5f, 0);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemySr = GetComponent<SpriteRenderer>();
        //playerAnim = GetComponent<Animator>();

        startPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //RAYCAST
        Vector2 rayStart = transform.position;
        RaycastHit hitInfo;
        Physics.Raycast(rayStart, rayDir, out hitInfo, 5);
        Debug.DrawRay(rayStart, rayDir * 5, Color.magenta);

        enemyPos = transform.position;
        findPlayer = GameObject.FindGameObjectWithTag("Player");

        //MOVING
        velocity = Vector2.MoveTowards(enemyPos, findPlayer.transform.position, speed * Time.deltaTime);
        //velocity.x = speed * Time.deltaTime;

        if (velocity.x > 0)
        {
            enemySr.flipX = false;
            rayDir.x = Mathf.Abs(rayDir.x);
        }

        if (velocity.x < 0)
        {
            enemySr.flipX = true;
            rayDir *= -1;
        }

        //RIGIDBODY
        rb.MovePosition(velocity);

    }//END OF UPDATE
}
