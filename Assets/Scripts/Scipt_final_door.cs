using UnityEngine;

public class Script_Final_Door : MonoBehaviour
{
    public Script_PickUP_Key keyPickup; 
    private Animator animator;          
    private Collider doorCollider;      

    private void Start()
    {
        animator = GetComponent<Animator>();
        doorCollider = GetComponent<Collider>(); 

    }

    private void OnTriggerEnter(Collider other)
    {
        print("enter");
        if (other.CompareTag("Player") && keyPickup != null && keyPickup.canOpenDoor)
        {
            Debug.Log("Player triggered the door. Opening door...");

            animator.SetTrigger("openDoor");

        }
        else if (other.CompareTag("Player") && keyPickup.canOpenDoor == false)
        {
            Debug.Log("Player triggered the door, but canOpenDoor is false.");
        }
    }
}
