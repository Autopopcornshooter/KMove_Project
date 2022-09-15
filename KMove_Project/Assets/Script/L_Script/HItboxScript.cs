using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HItboxScript : MonoBehaviour
{
   Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player Damaged!");
        }
        else if(other.gameObject.tag == "Sheild")
        {
            Debug.Log("Sheild hit!");
            animator.SetTrigger("Parried");
        }
        else if (other.gameObject.tag == "Sword")
        {
            Debug.Log("Sword hit!");
            animator.SetTrigger("Blocked");
        }
    }
}
