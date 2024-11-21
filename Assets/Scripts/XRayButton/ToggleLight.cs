using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ToggleLight : MonoBehaviour
{

    public GameObject XRayLight;
    public GameObject SpotLight;
    public GameObject RoomLight;
    public int intDamage;
    private bool boolXRay;
    private bool boolRoomLight;
    public DealDamage damageManager;
    public GameObject player;
    public LayerMask layersToHit;

    // Start is called before the first frame update
    void Start()
    {
        XRayLight.SetActive(false);
        SpotLight.SetActive(false);
        boolXRay = false;
        RoomLight.SetActive(true);
        boolRoomLight = true;

    }

    // Update is called once per frame
    void Update()
    {
        var rayDirection = player.transform.position - XRayLight.transform.position;
        //If que controla se o raio X está ligado ou não
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(boolXRay == true)
            {
                XRayLight.SetActive(false);         
                SpotLight.SetActive(false);       
                boolXRay = false;
            }
            else if (boolXRay == false)
            {
                if(boolRoomLight == false)
                {
                    XRayLight.SetActive(true);
                    SpotLight.SetActive(true);
                }
                boolXRay = true;
            }
        }

        //If que controla se a visão é normal ou do raio X
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(boolRoomLight == true)
            {
                RoomLight.SetActive(false);
                boolRoomLight = false;
                if(boolXRay == true)
                {
                    XRayLight.SetActive(true);
                    SpotLight.SetActive(true);
                }
            }
            else
            {
                RoomLight.SetActive(true);
                boolRoomLight = true;
                if(boolXRay == true)
                {
                    XRayLight.SetActive(false);
                    SpotLight.SetActive(false);
                    boolXRay = false;
                }
            }
        }

        //Verifica se a luz está ligada e causa dano ao player de acordo
        if (Physics.Raycast(XRayLight.transform.position, rayDirection, out RaycastHit hit, 100.0f, layersToHit))
        {
            if(boolXRay & (hit.transform.position.x == player.transform.position.x) & (hit.transform.position.z == player.transform.position.z))
            {    
                damageManager.SendDamage(intDamage);
            }
        }
    }
    public bool XRayState()
    {
        return boolXRay;
    }
}

