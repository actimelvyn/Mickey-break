using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PickUp_bottle : MonoBehaviour
{
    // Public and serialized fields
    public GameObject PostProcessVolume;
    public GameObject PickUpText;
    public bool drank;
    public Animator bottleAnim;
    public GameObject bottle;
    public SC_FPSController SC_FPSController;
    public float delayBeforEffect = 5f; // Delay in seconds before the effect

    // Class-level variable for caching "BW" objects
    private GameObject[] bwObjects;

    void Start()
    {
        // Initialize components
        PostProcessVolume.SetActive(false);
        PickUpText.SetActive(false);
        drank = false;

        // Find and cache SC_FPSController
        if (SC_FPSController == null)
        {
            SC_FPSController = FindObjectOfType<SC_FPSController>();
            if (SC_FPSController == null)
            {
                Debug.LogError("SC_FPSController not found in the scene!");
            }
        }

        // Temporarily disable movement
        SC_FPSController.walkingSpeed = 0;
        SC_FPSController.runningSpeed = 0;
        SC_FPSController.jumpSpeed = 0;

        // Cache all objects with the "BW" tag
        bwObjects = GameObject.FindGameObjectsWithTag("BW");
        foreach (GameObject obj in bwObjects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                foreach (Material material in renderer.materials)
                {
                    if (material.HasProperty("_Activator"))
                    {
                        material.SetFloat("_Activator", 0f); // Set _Activator to false
                        Debug.Log("Material _Activator set to false.");
                    }
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PickUpText.SetActive(true);

            if (Input.GetKey(KeyCode.E) && !drank)
            {
                // Trigger drinking animation
                if (bottleAnim != null) bottleAnim.SetTrigger("drink");
                StartCoroutine(DrinkEffectAfterDelay()); // Start the coroutine
                drank = true;

                // Hide or destroy the pickup text
                if (PickUpText != null) PickUpText.SetActive(false);
                Destroy(PickUpText);



                Debug.Log("Drinking started.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PickUpText.SetActive(false);
        }
    }

    private IEnumerator DrinkEffectAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayBeforEffect);
        Debug.Log("Apply post-process effect after delay.");

        // Activate _Activator property for cached BW objects
        foreach (GameObject obj in bwObjects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                foreach (Material material in renderer.materials)
                {
                    if (material.HasProperty("_Activator"))
                    {
                        material.SetFloat("_Activator", 1.0f); // Set _Activator to true
                        Debug.Log("Material _Activator set to true.");
                    }
                }
            }
        }

        // Hide the bottle
        if (bottle != null) bottle.SetActive(false);

        // Activate post-process effect
        if (PostProcessVolume != null) PostProcessVolume.SetActive(true);

        // Restore movement settings
        if (SC_FPSController != null)
        {
            SC_FPSController.walkingSpeed = SC_FPSController.defwalkingSpeed;
            SC_FPSController.runningSpeed = SC_FPSController.defrunningSpeed;
            SC_FPSController.jumpSpeed = SC_FPSController.defjumpSpeed;
        }

        // Destroy this script if no longer needed
        Destroy(this);
    }
}
