using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class L_PlayerCtrl : MonoBehaviour {
    // Start is called before the first frame update
    Rigidbody rb;
    Vector3 damaged_pos;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Knock_Back(float atk_DMG)
    {
        if(transform.position.x < damaged_pos.x)
        {
            rb.AddForce(new Vector3(-atk_DMG*0.2f,0.0f,0.0f));
        }
        else
        {
            rb.AddForce(new Vector3(atk_DMG * 0.7f, 0.0f, 0.0f));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HitBox")
        {
            Debug.Log("Player KnockBack");
            damaged_pos = other.transform.position;
            Knock_Back(100.0f);
        }
    }
}
