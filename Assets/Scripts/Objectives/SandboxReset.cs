using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SandboxReset : MonoBehaviour
{
    public InputActionProperty ResetButton;

    // Update is called once per frame
    void Update()
    {
        if (ResetButton.action.WasPressedThisFrame())
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
