using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectivesHandler : MonoBehaviour
{
    public GameObject objColete, Player, XRay; 
    public TMPro.TextMeshProUGUI TextoColete, TextoXRay, TextoSala;
    public bool boolColetePosicionado, boolPlayerPosicionado, boolXRayAtivado;
    public LayerMask layersToHit;
    private bool boolXRayLight;

    // Start is called before the first frame update
    void Start()
    {
        boolXRayAtivado = false;
    }
    // Update is called once per frame
    void Update()
    {
        var rayDirection = Player.transform.position - XRay.transform.position;
        ToggleLight LightState = GameObject.FindGameObjectWithTag("XRay").GetComponent<ToggleLight>();
        boolXRayLight = LightState.XRayState();

        if (objColete.transform.position == new Vector3(1.6f, 1.3f, -4.75f))
        {
            boolColetePosicionado = true;
            Debug.Log("Colete posicionado");
        }
        if (Physics.Raycast(XRay.transform.position, rayDirection, out RaycastHit hit, 100.0f, layersToHit))
        {
            if((hit.transform.position.x == Player.transform.position.x) & (hit.transform.position.z == Player.transform.position.z))
            {    
                boolPlayerPosicionado = false;
            }
            else
            {
                boolPlayerPosicionado = true;
                TextoSala.text = "- "+"<s>"+"Entre na sala segura"+"</s>";
            }
        }
        if (boolXRayLight)
        {
            boolXRayAtivado = true;
        }
        if (boolXRayLight && !boolPlayerPosicionado)
        {
            Debug.Log("Failed");
        }
    }
}
