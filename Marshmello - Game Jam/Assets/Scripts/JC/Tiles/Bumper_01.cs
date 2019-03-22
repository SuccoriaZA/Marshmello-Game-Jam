using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper_01 : MonoBehaviour
{

    public float _bumpSpeed;
    public Vector2 _bumpDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
    Rigidbody2D rb = other.transform.GetComponent<Rigidbody2D>();
    rb.AddForce( rb.velocity * _bumpSpeed, ForceMode2D.Impulse);


    }

    
}
