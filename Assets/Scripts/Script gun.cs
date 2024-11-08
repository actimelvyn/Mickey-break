using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class scriptgun : monobehaviour
//{
//    public float damage = 10f;
//    public float range = 100f;

//    public camera fpscam;
//    update is called once per frame
//    void update()
//    {
//        if (input.getmousebuttondown(1))
//        {
//            shoot();
//        }
//    }

//    void shoot()
//    {
//        raycasthit hit;
//        if (physics.raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
//        {
//            debug.log(hit.transform.name);

//            target target = hit.transform.getcomponent<target>();

//            if (target != null)
//            {
//                target.takedamage(damage);

//            }

//        }
//    }
//}
