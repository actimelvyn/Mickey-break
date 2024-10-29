using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PickUp_Light : MonoBehaviour
{

    public GameObject LightOnPlayer;

    // Start is called before the first frame update
    void Start()
    {
        LightOnPlayer.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyUp(KeyCode.E)) 
            {
                this.gameObject.SetActive(false);

                LightOnPlayer.SetActive(true);
            }
        }
    }

}
