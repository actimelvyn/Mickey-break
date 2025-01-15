using UnityEngine;

public class Script_Final_Door : MonoBehaviour
{
    public Script_PickUP_Key keyPickup; // Reference to the key pickup script
    private Animator animator;          // Reference to the door animator

    private void Start()
    {
        // Get the Animator component attached to the door
        animator = GetComponent<Animator>();

        // Check if the key pickup script is assigned
        if (keyPickup == null)
        {
            Debug.LogError("Script_PickUP_Key not assigned! Please assign it in the Inspector.");
        }

        // Check if the Animator component is attached
        if (animator == null)
        {
            Debug.LogError("Animator component not found on the door!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player entered the trigger and canOpenDoor is true
        if (other.CompareTag("Player") && keyPickup != null && keyPickup.canOpenDoor)
        {
            Debug.Log("Player triggered the door. Opening door...");

            // Trigger the door opening animation
            animator.SetTrigger("open");
        }
        else if (other.CompareTag("Player"))
        {
            Debug.Log("Player triggered the door, but canOpenDoor is false.");
        }
    }
}
