using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float mySpeed;
    private GameObject player;
    public Vector3 initialPos;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        initialPos = player.transform.position;
    }

    void FixedUpdate()
    {
        if (player == null)
        {
            Debug.Log("Error: no Player found");
            return;
        }
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis ("Horizontal");
        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 pos = player.transform.position;
        Vector3 dir = new Vector3(moveHorizontal,moveVertical).normalized;

        Vector3 targetPos = player.transform.position + dir * mySpeed;

        RaycastHit2D hit = Physics2D.Raycast(pos + (float)0.04*dir,dir,mySpeed);

        if(hit.collider == null ){
            player.transform.position = targetPos;


        }else {
            if(hit.collider.tag == "Finish"){
                player.GetComponent<SpriteRenderer>().color = Color.yellow;
                player.transform.localScale = player.transform.localScale * (float) 1;
            }else if(hit.collider.tag == "WallPuto") {
                player.transform.position = initialPos;
            }else if(hit.collider.tag == "Wall") {
                // faz nada 
            }
        }
        

        

    }

    // int ReturnMySpeed(){
    //     return 30;
    // }
}
