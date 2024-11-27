using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PickUp_Light : MonoBehaviour
{
    public GameObject LightOnPlayer;
    public GameObject PickUpText;
    public Renderer targetRenderer; // Renderer of the object to which materials are applied
    public Material outlineBlack;
    public Material outlineWhite;

    void Start()
    {
        LightOnPlayer.SetActive(false);
        PickUpText.SetActive(false);

        // Ensure materials are not applied initially
        if (targetRenderer != null)
        {
            targetRenderer.material = null; // Remove any assigned material at the start
        }
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

                // Apply materials to the Renderer
                if (targetRenderer != null)
                {
                    targetRenderer.materials = new Material[] { outlineBlack, outlineWhite };
                }
                else
                {
                    Debug.LogWarning("Target Renderer is not assigned!");
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PickUpText.SetActive(false);
    }
}
