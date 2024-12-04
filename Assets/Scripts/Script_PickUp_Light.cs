using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PickUp_Light : MonoBehaviour
{
    public GameObject LightOnPlayer;
    public GameObject PickUpText;

    void Start()
    {
        LightOnPlayer.SetActive(false);
        PickUpText.SetActive(false);

     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

                // Deactivate the pickup object
                this.gameObject.SetActive(false);

                // Activate the light
                LightOnPlayer.SetActive(true);

                // Hide the pickup text
                PickUpText.SetActive(false);


               
         
        }
    }

}
