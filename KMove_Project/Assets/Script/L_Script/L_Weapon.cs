using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Weapon : MonoBehaviour
{
    protected bool isBlocked = false;
    protected bool isParried = false;

    public virtual bool GetBlocked()
    {
        return false;
    }

    public virtual bool GetParried()
    {
        return false;
    }
}
