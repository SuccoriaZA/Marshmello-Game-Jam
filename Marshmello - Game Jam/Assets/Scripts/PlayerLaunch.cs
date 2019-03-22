using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaunch : MonoBehaviour
{

    public float velocity;

    Vector2 force;
 
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        force = new Vector2(velocity, 0f);
        rb2d.AddForce(force, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb2d.AddForce(force, ForceMode2D.Impulse);
    }
}
