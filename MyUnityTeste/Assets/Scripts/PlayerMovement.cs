using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float mySpeed;
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
        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxisRaw ("Vertical");
        
        if (Input.GetKeyDown("space"))
        {
            if(onFloor){
                Vector3 pushUp = new Vector3 (0f, 1f, 0f);
                rb.AddForce (pushUp * jump);
                onFloor = false;
            }

        }

        Vector3 pos = player.transform.position;
        Vector3 dir = new Vector3(moveHorizontal,0).normalized;

        targetPos = targetPos + dir * mySpeed;

        // //RaycastHit2D hit = Physics2D.Raycast(pos,dir,mySpeed);
        player.transform.position = targetPos;

            // if(hit.collider.tag == "Finish"){
            //     player.GetComponent<SpriteRenderer>().color = Color.yellow;
            //     player.transform.localScale = player.transform.localScale * (float) 1;
            // }else if(hit.collider.tag == "WallPuto") {
            //     player.transform.position = initialPos;
            // }else if(hit.collider.tag == "Wall") {
            //     // faz nada 
            // }
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
