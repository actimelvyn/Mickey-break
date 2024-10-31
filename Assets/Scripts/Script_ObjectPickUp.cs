using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_ObjectPickUp : MonoBehaviour
{

    public GameObject crosshair1, crosshair2;
    public Transform objectTransform, cameraTransform;
    public bool interactable, pickedup;
    public Rigidbody objectRigidbody;
    public float gravity;


    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            crosshair1.SetActive(false);
            crosshair2.SetActive(true);
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (pickedup == false)
            {
                crosshair1.SetActive(true);
                crosshair2.SetActive(false);
                interactable = false;
            }
            if (pickedup == true)
            {
                objectTransform.parent = null;
                objectRigidbody.useGravity = true;
                crosshair1.SetActive(true);
                crosshair2.SetActive(false);
                interactable = false;
                pickedup = false;
            }
        }
    }

    void Update()
    {
        if (interactable == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                objectTransform.parent = cameraTransform;
                objectRigidbody.useGravity = false;
                pickedup = true;
                objectRigidbody.isKinematic = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                objectTransform.parent = null;
                objectRigidbody.useGravity = true;
                objectRigidbody.velocity = cameraTransform.forward * gravity * Time.deltaTime;
                pickedup = false;
                objectRigidbody.isKinematic = false;
            }
        }
    }

}
