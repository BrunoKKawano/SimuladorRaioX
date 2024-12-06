using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ObjectivesHandler : MonoBehaviour
{
    public GameObject objColete, Player, XRay, FailedCanva, HUDCanva, BemvindoCanva, SucessoCanva; 
    public TMPro.TextMeshProUGUI TextoColete, TextoXRay, TextoSala;
    public bool boolColetePosicionado, boolPlayerPosicionado, boolXRayAtivado;
    public LayerMask layersToHit;
    private bool boolXRayLight, boolFailed, boolSucesso;
    public InputActionProperty ResetButton;

    // Start is called before the first frame update
    void Start()
    {
        boolXRayAtivado = false;
        boolFailed = false;
        boolSucesso = false;
    }
    // Update is called once per frame
    void Update()
    {
        var rayDirection = Player.transform.position - XRay.transform.position;
        ToggleLight LightState = GameObject.FindGameObjectWithTag("XRay").GetComponent<ToggleLight>();
        boolXRayLight = LightState.XRayState();

        if (ResetButton.action.WasPressedThisFrame())
        {
            SceneManager.LoadScene("MainScene");
        }

        if (objColete.transform.position == new Vector3(1.6f, 1.3f, -4.75f))
        {
            boolColetePosicionado = true;
            TextoColete.text = "- <s>Entregue o colete ao paciente</s>";
        } else{
            boolColetePosicionado = false;
            TextoColete.text = "- Entregue o colete ao paciente";
        }
        if (Physics.Raycast(XRay.transform.position, rayDirection, out RaycastHit hit, 100.0f, layersToHit))
        {
            if((hit.transform.position.x == Player.transform.position.x) && (hit.transform.position.z == Player.transform.position.z))
            {    
                boolPlayerPosicionado = false;
                TextoSala.text = "- Entre na sala segura";
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
            TextoXRay.text = "- <s>Ligue o raio X</s>";
        } else{
            boolXRayAtivado = false;
        }
        if (((boolXRayAtivado && !(boolPlayerPosicionado)) || (boolXRayAtivado && !boolColetePosicionado) || (boolFailed)) && !boolSucesso)
        {
            boolFailed = true;
            FailedCanva.SetActive(true);
            HUDCanva.SetActive(false);
            BemvindoCanva.SetActive(false);
        } else if ((boolXRayLight && boolColetePosicionado && boolPlayerPosicionado) || boolSucesso)
        {
            boolSucesso = true;
            SucessoCanva.SetActive(true);
        }
    }
}
