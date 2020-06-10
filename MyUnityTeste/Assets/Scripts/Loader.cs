using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public static string actual = "Level1";

    public static void Load(string scene)
    {
        SceneManager.LoadScene(scene);
        actual = scene; 
    }
}
