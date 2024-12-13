using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Scipt_final_door : MonoBehaviour
{
    private int interactable = 1;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && interactable == 2)
        {
            GetComponent<BoxCollider>().isTrigger = true ;
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
