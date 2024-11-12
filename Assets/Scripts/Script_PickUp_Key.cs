using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PickUp_Key : MonoBehaviour
{

    public GameObject KeyOnPlayer;
    public GameObject PickUpText;

    // Start is called before the first frame update
    void Start()
    {
        KeyOnPlayer.SetActive(false);
        PickUpText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag ("Player"))
        {
            PickUpText.SetActive(true);

            if (Input.GetKeyUp(KeyCode.E))
            {
                this.gameObject.SetActive(false);

                KeyOnPlayer.SetActive(true);

                PickUpText.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PickUpText.SetActive(false);
    }

}
