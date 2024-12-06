using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    void Update() {
        
    }
    void QuitGame () {
        Application.Quit ();
        Debug.Log("Game is exiting");
        //Just to make sure its working
    }
}
