using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4A1 : Gun
{

    void FixedUpdate()
    {
        Debug.DrawRay(bulletSource.transform.position, -bulletSource.transform.forward * range, Color.green);
        if (Input.GetButton("Fire1"))
        {
             Shoot();
        }
    }
}
