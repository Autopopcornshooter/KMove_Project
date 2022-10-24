using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_EnemyCtrl : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private L_HitboxScript hitboxScript;
    private void Start()
    {
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Enemy_Attack();
        }
    }
    private void Enemy_Attack()
    {
        animator.SetTrigger("Attack");
        hitboxScript.Attack();
    }
   

    
}
