using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_HitboxScript : MonoBehaviour
{
    [SerializeField]
  private Animator animator;
    private BoxCollider collider;
    private void Start()
    {
        collider = GetComponent<BoxCollider>();
        collider.enabled = false;
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
        StartCoroutine(HitboxEnable());
    }
    IEnumerator HitboxEnable()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        collider.enabled = true;
        yield return new WaitForSecondsRealtime(0.5f);
        collider.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Untagged")
        {
            collider.enabled = false;
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("Player Damaged!");
            }
            else if (other.gameObject.tag == "Sheild")
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
}
