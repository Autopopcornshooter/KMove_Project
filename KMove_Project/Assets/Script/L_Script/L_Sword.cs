using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Sword : L_Weapon
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override bool GetBlocked()
    {
        base.GetBlocked();
        return isBlocked;
    }
    public override bool GetParried()
    {
        base .GetParried();
        return isParried;
    }
    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hitbox")
        {
            isBlocked = true;
        }
    }
}
