using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PickUp_bottle : MonoBehaviour
{
    // l'objet doit avoir les 3 materiels et avoir le tag BW
    public GameObject PostProcessVolume;
    public GameObject PickUpText;
    public bool drank;
    public Animator bottleAnim;
    public GameObject bottle;

    public float delayBeforEffect = 5f; // Delay in seconds before breaking

    //[System.Serializable]
    /*public class TargetObject
    {
        public Renderer renderer;         // Renderer of the object
        public bool useBothMaterials;     // Whether to apply both materials
        [HideInInspector] public Material[] originalMaterials; // Stores the original materials
    }*/

    //public List<TargetObject> targetObjects; // List of objects with their material settings
    public Material outlineBlack;
    public Material outlineWhite;

    void Start()
    {
        PostProcessVolume.SetActive(false);
        PickUpText.SetActive(false);
        drank = false;


        // Store original materials for all objects
       /* foreach (TargetObject target in targetObjects)
        {
            if (target.renderer != null)
            {
                target.originalMaterials = target.renderer.materials; // Store the current materials
            }
        }*/


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
                        material.SetFloat("_Activator", 0f); // Set _Activator to false
                        print("onn");
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

            if (Input.GetKey(KeyCode.E))
            {
                bottleAnim.SetTrigger("drink"); // Trigger the vase animation
                StartCoroutine(DrinkEffectAfterDelay()); // Start the breaking vase coroutine


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

    private IEnumerator DrinkEffectAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayBeforEffect);
        Debug.Log("Apply post Process after delay");
        // Deactivate the pickup object
        if (bottle != null) this.gameObject.SetActive(false);
        // Activate the light
        if (PostProcessVolume != null) PostProcessVolume.SetActive(true);

        // Optionally destroy this script
        Destroy(this); // Removes the script from the GameObject
    }
}
