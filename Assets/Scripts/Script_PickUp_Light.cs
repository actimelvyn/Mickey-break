using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PickUp_Light : MonoBehaviour
{
    public GameObject LightOnPlayer;
    public GameObject PickUpText;
    public Material targetMaterial; // Reference to the material with the _Activator property

    void Start()
    {
        LightOnPlayer.SetActive(false);
        PickUpText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PickUpText.SetActive(true);

            if (Input.GetKeyUp(KeyCode.E))
            {
                // Deactivate the pickup object
                this.gameObject.SetActive(false);

                // Activate the light
                LightOnPlayer.SetActive(true);

                // Hide the pickup text
                PickUpText.SetActive(false);

                // Change the _Activator property of the material
                if (targetMaterial != null)
                {
                    targetMaterial.SetFloat("_Activator", 1f);
                }
                else
                {
                    Debug.LogWarning("Target Material is not assigned!");
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PickUpText.SetActive(false);
    }
}
