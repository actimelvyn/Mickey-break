using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PickUp_bottle : MonoBehaviour
{
    public GameObject LightOnPlayer;
    public GameObject PickUpText;
    public bool drank;

    [System.Serializable]
    public class TargetObject
    {
        public Renderer renderer;         // Renderer of the object
        public bool useBothMaterials;     // Whether to apply both materials
        [HideInInspector] public Material[] originalMaterials; // Stores the original materials
    }

    public List<TargetObject> targetObjects; // List of objects with their material settings
    public Material outlineBlack;
    public Material outlineWhite;

    void Start()
    {
        LightOnPlayer.SetActive(false);
        PickUpText.SetActive(false);
        drank = false;

        // Store original materials for all objects
        foreach (TargetObject target in targetObjects)
        {
            if (target.renderer != null)
            {
                target.originalMaterials = target.renderer.materials; // Store the current materials
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PickUpText.SetActive(true);

            if (Input.GetKey(KeyCode.E))
            {
                // Deactivate the pickup object
                this.gameObject.SetActive(false);

                // Activate the light
                LightOnPlayer.SetActive(true);

                // Hide the pickup text
                PickUpText.SetActive(false);

                drank = true;

                // Find all objects with the tag "BW"
                GameObject[] bwObjects = GameObject.FindGameObjectsWithTag("BW");

                foreach (GameObject obj in bwObjects)
                {
                    Renderer renderer = obj.GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        // Activate the _Activator property for all materials
                        foreach (Material material in renderer.materials)
                        {
                            if (material.HasProperty("_Activator"))
                            {
                                material.SetFloat("_Activator", 1.0f); // Set _Activator to true
                                print("onn");
                            }
                        }
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PickUpText.SetActive(false);
    }
}
