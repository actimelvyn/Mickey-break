using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PickUp_Light : MonoBehaviour
{
    public GameObject LightOnPlayer;

    void Start()
    {
        LightOnPlayer.SetActive(false);

     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

                // Deactivate the pickup object
                this.gameObject.SetActive(false);

                // Activate the light
                LightOnPlayer.SetActive(true);


               
         
        }
    }

}
