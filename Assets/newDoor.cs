using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newDoor1 : MonoBehaviour
{
    public GameObject intText;
    public bool interactable, toggle;
    public Animator doorAnim;
    public bool planchpickup; //a mettre en false en start et true une fois que dans le code de la plache la planche est recuperer
    


    private void Start()
    {
        interactable = false;
        intText.SetActive(false);
        planchpickup = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            intText.SetActive(true);
            interactable = true;

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            intText.SetActive(false);
            interactable = false;
        }
    }

    private void Update()
    {
        if ((interactable == true) && (Input.GetKeyUp(KeyCode.E))) //&& (planchpickup == true)) 
        {
            doorAnim.SetTrigger("open");
            intText.SetActive(false);
            Debug.Log("open");

        }

       

    }
}
