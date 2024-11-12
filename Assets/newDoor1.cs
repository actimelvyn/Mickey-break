using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class newDoor : MonoBehaviour
{
    public GameObject intText;
    public bool interactable1, toggle;
    public Animator doorAnim;
    public bool key;

    private void Start()
    {
        intText.SetActive(false);
        interactable1 = false;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
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
        if ((interactable1 == true) && (Input.GetKeyUp(KeyCode.E))) // && (key == true))
        {
            doorAnim.SetTrigger("open");
            intText.SetActive(false);

        }



    }
}
