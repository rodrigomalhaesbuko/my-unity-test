using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishComponent : MonoBehaviour
{
    public string nextLevel;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "player")
        {
            Debug.Log(nextLevel);
            Loader.Load(nextLevel);
        }
    }
}
