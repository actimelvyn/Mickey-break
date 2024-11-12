using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject door_closed, door_opened, intText;
    //public AudioSource open, close;
    private bool opened;
    private bool isPlayerInRange = false;

    private void Start()
    {
        Debug.Log("start");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            intText.SetActive(true);
            isPlayerInRange =  true;
            //Debug.Log("Is in range");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(false);
            isPlayerInRange = false;
            //Debug.Log("Is  NOT in range");

        }
    }

    private void OpenDoor()
    {
        door_closed.SetActive(false);
        door_opened.SetActive(true);
        intText.SetActive(false);
        //open.Play();
        opened = true;
        //Debug.Log("door opened");

    }

    void Update()
    {
        if (isPlayerInRange==true && opened==false && Input.GetKeyDown(KeyCode.E))
        {
            OpenDoor();
        }
    }

    
}
