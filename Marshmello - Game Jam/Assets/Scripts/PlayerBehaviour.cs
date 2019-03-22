using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

        public float velocity;

        Vector2 force;

        Rigidbody2D rb2d;

        Vector2 red;

        public float redSpeed;

        Vector2 blue;

        Vector2 yellow;

        // Start is called before the first frame update
        void Start () {
            rb2d = GetComponent<Rigidbody2D> ();
            force = new Vector2 (velocity, 0f);
            rb2d.AddForce (force, ForceMode2D.Impulse);
        }

        // Update is called once per frame
        void FixedUpdate () {
            //rb2d.AddForce(force, ForceMode2D.Impulse);
        }

        public void RedBehaviour () {
            rb2d.AddForce (transform.up*redSpeed, ForceMode2D.Impulse);
            }

        public void BlueBehaviour() {
            rb2d.AddForce (transform.up * -redSpeed, ForceMode2D.Impulse);
            }
        public void YellowBehaviour() {
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