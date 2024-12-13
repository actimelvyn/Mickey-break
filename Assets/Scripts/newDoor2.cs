using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newDoor2 : MonoBehaviour
{
    public GameObject intText; // Texte d'interaction
    public bool interactable2; // Si le joueur peut interagir avec la porte
    public Animator doorAnim; // Animation de la porte (si utilis�e)

    // R�f�rence au script de la cl�
    public Script_PickUP_Key scriptPickUpkey;

    private void Start()
    {
        // D�sactiver le texte d'interaction au d�part
        intText.SetActive(false);
        interactable2 = false;

        // Trouver automatiquement Script_PickUP_Key s'il n'est pas assign�
        if (scriptPickUpkey == null)
        {
            scriptPickUpkey = FindObjectOfType<Script_PickUP_Key>();
            if (scriptPickUpkey == null)
            {
                Debug.LogError("Script_PickUP_Key non trouv� dans la sc�ne !");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // V�rifie si le joueur entre dans le trigger et poss�de la cl�
        if (other.CompareTag("Player") && scriptPickUpkey != null && scriptPickUpkey.canOpenDoor)
        {
            intText.SetActive(true); // Affiche le texte d'interaction
            interactable2 = true;   // Permet l'interaction
            Debug.Log("Le joueur peut ouvrir la porte.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Cache le texte lorsque le joueur quitte le trigger
        if (other.CompareTag("Player"))
        {
            intText.SetActive(false);
            interactable2 = false;
        }
    }

    private void Update()
    {
        // V�rifie l'interaction du joueur avec la porte
        if (interactable2 && Input.GetKeyUp(KeyCode.E) && scriptPickUpkey != null && scriptPickUpkey.canOpenDoor)
        {
            // Jouer l'animation si d�finie
            if (doorAnim != null)
            {
                doorAnim.SetTrigger("open");
            }

            // D�sactiver la porte ou effectuer une autre action
            this.gameObject.SetActive(false);
            Destroy(intText); // Supprime le texte d'interaction
            Debug.Log("La porte s'ouvre !");
        }
    }
}
