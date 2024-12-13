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
    public SC_FPSController SC_FPSController;

    public float delayBeforEffect = 5f; // Delay in seconds before 
    void Start()
    {
        PostProcessVolume.SetActive(false);
        PickUpText.SetActive(false);
        drank = false;

        if (SC_FPSController == null)
        {
            SC_FPSController = FindObjectOfType<SC_FPSController>();
            if (SC_FPSController == null)
            {
                Debug.LogError("SC_FPSController non trouvé dans la scène !");
            }
        }
        //SC_FPSController.canMove = false;
        SC_FPSController.walkingSpeed = 0;
        SC_FPSController.runningSpeed = 0;
        SC_FPSController.jumpSpeed = 0;


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
                //PickUpText.SetActive(false);
                Destroy(PickUpText);

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
        //SC_FPSController.canMove = true;
        SC_FPSController.walkingSpeed = SC_FPSController.defwalkingSpeed;
        SC_FPSController.runningSpeed = SC_FPSController.defrunningSpeed;
        SC_FPSController.jumpSpeed = SC_FPSController.defjumpSpeed;
    }
}
