using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin_Disk : MonoBehaviour
{
    public float _waitTime;

    public float _shootSpeed;
    public Vector2 _shootDirection;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0,-1));
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
           rb = other.transform.GetComponent<Rigidbody2D>();
           rb.transform.SetParent(gameObject.transform, true);
            StartCoroutine(PlayerStuck());
            rb.gravityScale = 0;
            
        }
    }
        IEnumerator PlayerStuck()
        {
            rb.velocity = new Vector2(0,0);
            //rb.gravityScale = 0;
           // rb.isKinematic = true;
           // rb.transform.SetParent(this.transform);
            yield return new WaitForSeconds(_waitTime);
            {
              rb.transform.SetParent(null);
           // rb.isKinematic = false;
             rb.gravityScale = 1;
             rb.AddForce(_shootDirection*_shootSpeed, ForceMode2D.Impulse); 
            }
            //rb.gravityScale = 1;

        }


void OnTriggerExit2D(Collider2D other)
{
    if (other.transform.tag == "Player" && other.transform.GetComponent<Rigidbody2D>().gravityScale == 0)

    {
        other.transform.GetComponent<Rigidbody2D>().gravityScale = 1;
    } 
}


}
