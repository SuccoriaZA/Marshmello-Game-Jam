using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerBehaviour : MonoBehaviour {

    public float velocity;

    Vector2 force;

    Rigidbody2D rb2d;

    Vector2 red;

    public float redSpeed;
    public float dashSpeed;

    Vector2 blue;

    Vector2 yellow;

    public bool ativeMove = true;

    [SerializeField] float counterUp = 1;
    float counterUpCurrent;
    [SerializeField] float counterRight = 1;
    float counterRightCurrent;
    [SerializeField] float counterDown = 1;
    float counterDownCurrent;

    public Vector2 pos1;

    public float maxdist;

    public Vector2 pos2;

    // Start is called before the first frame update
    void Start () {
        rb2d = GetComponent<Rigidbody2D> ();
        force = new Vector2 (velocity, 0f);
      //  rb2d.AddForce (force, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update () {
        if (counterUpCurrent > 0) {
            counterUpCurrent -= Time.deltaTime;
        } else {
            if (Input.GetKeyDown (KeyCode.UpArrow) && ativeMove == true) {
                rb2d.AddForce (transform.up * dashSpeed, ForceMode2D.Impulse);
                counterUpCurrent = counterUp;
            }
        }
        if (counterRightCurrent > 0) {
            counterRightCurrent -= Time.deltaTime;
        } else {
            if (Input.GetKeyDown (KeyCode.RightArrow) &&ativeMove == true) {
                rb2d.AddForce (transform.right * dashSpeed, ForceMode2D.Impulse);
                counterRightCurrent = counterRight;
            }
        }

        if (counterDownCurrent > 0) {
            counterDownCurrent -= Time.deltaTime;
        } else {
            if (Input.GetKeyDown (KeyCode.DownArrow) && ativeMove == true) {
                rb2d.AddForce (transform.up * -dashSpeed, ForceMode2D.Impulse);
                counterDownCurrent = counterDown;
            }
        }

        if (rb2d.velocity.x < 0.5 && rb2d.velocity.x > -0.5 && ativeMove == false)
        {
            pos2 = gameObject.transform.position;

            maxdist = Vector2.Distance(pos2,pos1);
            Debug.Log(maxdist);

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Final",LoadSceneMode.Single);
        }
    }

    public void RedBehaviour () {
        rb2d.AddForce (transform.up * redSpeed, ForceMode2D.Impulse);
    }

    public void BlueBehaviour () {
        rb2d.AddForce (transform.up * -redSpeed, ForceMode2D.Impulse);
    }
    public void YellowBehaviour () {
        rb2d.AddForce (transform.right * redSpeed, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.transform.tag == "Red") {
            RedBehaviour ();
        }
        if (other.transform.tag == "Blue") {
            BlueBehaviour ();
        }
        if (other.transform.tag == "Yellow") {
            YellowBehaviour ();
        }

        if (other.transform.tag == "Round_end")
        {
            ativeMove = false;
            pos1 = gameObject.transform.position;
            

        }
    }
}