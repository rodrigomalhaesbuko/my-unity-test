using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMovement : MonoBehaviour
{   
    public float speed = 5;
    public GameObject trap; 
    Vector3 pushRight;
    Vector3 pushLeft;
    Vector3 lastForce;
    public Rigidbody2D rb;
 
    // Use this for initialization
    void Start () {
        rb = trap.GetComponent<Rigidbody2D>();
        pushRight = new Vector3 (0f, 20f, 0f);
        pushLeft = new Vector3 (0f, -20f, 0f);
        rb.AddForce (pushRight * speed);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "down") {
            lastForce = pushRight * speed;
            rb.AddForce (lastForce);
            }
        if (other.gameObject.tag == "up") {
            lastForce = pushLeft * speed;
            rb.AddForce (lastForce);
        }
    }
}
