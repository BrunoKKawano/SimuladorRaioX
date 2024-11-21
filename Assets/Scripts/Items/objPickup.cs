using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objPickup : MonoBehaviour
{
    public GameObject crosshair1, crosshair2, Table, objColete;
    public Transform objTransform, cameraTrans;
    public bool interactable, pickedup, positioned;
    public Rigidbody objRigidbody;
    public float throwAmount;
    private float flDistanceFromTable;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Debug.Log("Trigger ativada");
            crosshair1.SetActive(false);
            crosshair2.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger desativada");
        if (other.CompareTag("MainCamera"))
        {
            if(pickedup == false)
            {
                crosshair1.SetActive(true);
                crosshair2.SetActive(false);
                interactable = false;
            }
            if (pickedup == true)
            {
                objTransform.parent = null;
                objRigidbody.useGravity = true;
                crosshair1.SetActive(true);
                crosshair2.SetActive(false);
                interactable = false;
                pickedup = false;
            }
        }
    }
    void Update()
    {
        if (Vector3.Distance(objColete.transform.position, Table.transform.position)>= 5)
        {
            positioned = false;
        }
        if (interactable == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                objTransform.parent = cameraTrans;
                objRigidbody.useGravity = false;
                pickedup = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                if ((Vector3.Distance(objColete.transform.position, Table.transform.position)< 5) && (positioned == false))
                {
                    Debug.Log("Objeto proximo");
                    objColete.transform.position = new Vector3(1, 2, 3);
                    objTransform.parent = null;
                    objRigidbody.useGravity = false;
                    objRigidbody.velocity = new Vector3(0,0,0);
                    objRigidbody.angularVelocity = new Vector3(0,0,0);
                    pickedup = false;
                    positioned = true;
                }
                else
                {
                    objTransform.parent = null;
                    objRigidbody.useGravity = true;
                    pickedup = false;
                }
            }
            if(pickedup == true)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    objTransform.parent = null;
                    objRigidbody.useGravity = true;
                    objRigidbody.velocity = cameraTrans.forward * throwAmount * Time.deltaTime;
                    pickedup = false;
                }
            }
        }
    }
}