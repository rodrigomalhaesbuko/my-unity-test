using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public float npcSpeed;
    public GameObject npc;
    public float acceleration;
    float vel = 0; 
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        if (npc == null)
        {
            Debug.Log("Error: no Player found");
            return;
        }

        Vector3 pos = npc.transform.position;
        vel +=  npcSpeed * acceleration;
        pos.x += vel;

        npc.transform.position = pos;

    }
}
