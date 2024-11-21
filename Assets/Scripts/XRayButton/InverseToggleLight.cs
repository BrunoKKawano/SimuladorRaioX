using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseToggleLight : MonoBehaviour
{

    public GameObject Light;
    public bool boolRoomLight;
    // Start is called before the first frame update
    void Start()
    {
        Light.SetActive(true);
        boolRoomLight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(boolRoomLight == true)
            {
                Light.SetActive(false);
                boolRoomLight = false;
            }
            else if (boolRoomLight == false)
            {
                Light.SetActive(true);
                boolRoomLight = true;
            }
        }
    }
}
