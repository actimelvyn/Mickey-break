using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scriptgun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera FPScam;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPScam.transform.position, FPScam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

           Target target = hit.transform.GetComponent<Target>();

            if (target != null)
            {
                target.TakeDamage(damage);

            }

        }
    }
}
