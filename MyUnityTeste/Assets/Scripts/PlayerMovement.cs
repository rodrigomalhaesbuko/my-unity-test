using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float mySpeed;
    private GameObject player;

    void Start()
    {
        // mySpeed = ReturnMySpeed();
        player = GameObject.FindGameObjectWithTag("player");
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
        pos.x += mySpeed * moveHorizontal;
        pos.y +=  mySpeed * moveVertical;

        player.transform.position = pos;

    }

    // int ReturnMySpeed(){
    //     return 30;
    // }
}
