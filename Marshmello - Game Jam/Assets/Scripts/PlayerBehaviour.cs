using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    public float velocity;

    Vector2 force;

    Rigidbody2D rb2d;

    Vector2 red;

    public float redSpeed;
    public float dashSpeed;

    Vector2 blue;

    Vector2 yellow;

    [SerializeField] float counterUp = 1;
    float counterUpCurrent;
    [SerializeField] float counterRight = 1;
    float counterRightCurrent;
    [SerializeField] float counterDown = 1;
    float counterDownCurrent;

    // Start is called before the first frame update
    void Start () {
        rb2d = GetComponent<Rigidbody2D> ();
        force = new Vector2 (velocity, 0f);
        rb2d.AddForce (force, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update () {
        if (counterUpCurrent > 0) {
            counterUpCurrent -= Time.deltaTime;
        } else {
            if (Input.GetKeyDown (KeyCode.UpArrow)) {
                rb2d.AddForce (transform.up * dashSpeed, ForceMode2D.Impulse);
                counterUpCurrent = counterUp;
            }
        }
        if (counterRightCurrent > 0) {
            counterRightCurrent -= Time.deltaTime;
        } else {
            if (Input.GetKeyDown (KeyCode.RightArrow)) {
                rb2d.AddForce (transform.right * dashSpeed, ForceMode2D.Impulse);
                counterRightCurrent = counterRight;
            }
        }

        if (counterDownCurrent > 0) {
            counterDownCurrent -= Time.deltaTime;
        } else {
            if (Input.GetKeyDown (KeyCode.DownArrow)) {
                rb2d.AddForce (transform.up * -dashSpeed, ForceMode2D.Impulse);
                counterDownCurrent = counterDown;
            }
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
    }
}