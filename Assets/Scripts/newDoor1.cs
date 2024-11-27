using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newDoor : MonoBehaviour
{
    public GameObject intText;
    public bool interactable1, toggle;
    public Animator doorAnim;

    // Reference to the Script_PickUp_Light script
    public Script_PickUp_Light scriptPickUpLight;

    private void Start()
    {
        intText.SetActive(false);
        interactable1 = false;

        // Optional: Automatically find Script_PickUp_Light if it's on the same GameObject
        if (scriptPickUpLight == null)
        {
            scriptPickUpLight = FindObjectOfType<Script_PickUp_Light>();
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player") && scriptPickUpLight.drank)
        {
            intText.SetActive(true);
            interactable1 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            intText.SetActive(false);
            interactable1 = false;
        }
    }

    private void Update()
    {
        // Access the 'drank' bool from Script_PickUp_Light
        if (interactable1 && Input.GetKeyUp(KeyCode.E) && scriptPickUpLight.drank)
        {
            doorAnim.SetTrigger("open");
            intText.SetActive(false);
        }
    }
}
