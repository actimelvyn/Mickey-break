using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PickUP_Key : MonoBehaviour
{

    public GameObject keyOnPlayer;
    public bool interactable, toggle;
    public GameObject PickUpText;
    public Animator vaseAnim;

    // Start is called before the first frame update
    void Start()
    {
        keyOnPlayer.SetActive(false);
        PickUpText.SetActive(false);
        interactable = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PickUpText.SetActive(true);
            interactable = true;

            if (Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);

                keyOnPlayer.SetActive(true);

                PickUpText.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PickUpText.SetActive(false);
        interactable = false;
    }

    private void Update()
    {
        if ((interactable == true) && (Input.GetKeyUp(KeyCode.E)))
        {
            vaseAnim.SetTrigger("pick_up");
            PickUpText.SetActive(false);

        }



    }

}
