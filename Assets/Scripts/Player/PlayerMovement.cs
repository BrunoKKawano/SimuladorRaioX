using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   public GameObject Player, XRRig;
    // Update is called once per frame
    void Update()
    {
        Player.transform.position = XRRig.transform.position;
    }
}
