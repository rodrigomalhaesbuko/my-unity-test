using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float mySpeed;
    public bool onDash;
    private GameObject player;
    private Vector3 initialPos;

    public float jump;

    private bool onFloor = true; 
    public Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        rb = player.GetComponent<Rigidbody2D>();
        initialPos = player.transform.position;
    }

    void FixedUpdate()
    {
        if (player == null)
        {
            Debug.Log("Error: no Player found");
            return;
        }
        Vector3 targetPos = player.transform.position;
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxisRaw ("Horizontal");
        ////Store the current vertical input in the float moveVertical.
        //float moveVertical = Input.GetAxisRaw ("Vertical");
        
        if (Input.GetKeyDown("space"))
        {
            if(onFloor){
                Vector3 pushUp = new Vector3 (0f, 1f, 0f);
                rb.AddForce (pushUp * jump);
                onFloor = false;
            }

        }

        Vector3 dir;

        if (!onFloor)
        {
            transform.Rotate(new Vector3(0, 0, -2));
        }

        if (onDash)
        {
            dir = new Vector3(1, 0).normalized;
        }
        else{
            dir = new Vector3(moveHorizontal, 0).normalized;
        }

        targetPos += dir * mySpeed;

        player.transform.position = targetPos;
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "WallPuto") {
            Loader.Load(Loader.actual);
         }
        if (other.gameObject.tag == "down") {
            onFloor = true;

        }
    }
    
}
