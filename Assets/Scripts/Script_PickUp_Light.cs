using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PickUp_Light : MonoBehaviour
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
            print("aaa");
            if (Input.GetKey(KeyCode.E))
            {
                print("bbb");
                // Deactivate the pickup object
                this.gameObject.SetActive(false);

                // Activate the light
                LightOnPlayer.SetActive(true);

                // Hide the pickup text
                PickUpText.SetActive(false);

                drank = true;

                // Assign additional materials to each target
                foreach (TargetObject target in targetObjects)
                {
                    if (target.renderer != null)
                    {
                        // Combine original materials with the new materials
                        List<Material> combinedMaterials = new List<Material>(target.originalMaterials);

                        if (target.useBothMaterials)
                        {
                            combinedMaterials.Add(outlineBlack);
                            combinedMaterials.Add(outlineWhite);
                        }
                        else
                        {
                            combinedMaterials.Add(outlineBlack); // Add only one material
                        }

                        target.renderer.materials = combinedMaterials.ToArray(); // Update materials
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

