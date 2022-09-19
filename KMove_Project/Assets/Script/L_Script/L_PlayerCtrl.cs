using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class L_PlayerCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    Vector3 damaged_pos;
    private bool isDamaged;


    [SerializeField]
    private float Speed = 10;
    [SerializeField]
    private float Sensitivity = 10;
    [SerializeField]
    private float GravityAccel = 0.0981f;

    private Vector3 Direction = Vector3.zero;
    private float GravitySpeed = 0.0f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }

    private void Update()
    {
        RaycastHit hit;
        if (!isDamaged)
        {
           
            Direction = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

            if (Direction.sqrMagnitude > 0.01f)
            {
                transform.forward = Direction;
                if (!Physics.CapsuleCast(transform.position + Vector3.up * 0.7f, transform.position + Vector3.up * 2, 0.3f, Direction, 0.3f))
                    transform.position += Direction * Speed * Time.deltaTime;
            }

            
        }
        if (Physics.Raycast(transform.position, Vector3.down * 0.5f, out hit, 1.0f))
        {
            GravitySpeed = 0;
            transform.position += new Vector3(0, 1 - hit.distance, 0);
        }
        else
        {
            if (GravitySpeed < 10)
                GravitySpeed += GravityAccel;
            transform.position += new Vector3(0, -GravitySpeed, 0) * Time.deltaTime;
        }
    }
    IEnumerator Knock_Back(float atk_DMG)
    {
        isDamaged = true;
        rb.velocity = Vector3.zero;
        if (transform.position.x < damaged_pos.x)
        {
            rb.AddForce(new Vector3(-atk_DMG * 0.2f, 0.0f, 0.0f));
        }
        else
        {
            rb.AddForce(new Vector3(atk_DMG * 0.7f, 0.0f, 0.0f));
        }
        yield return new WaitForSeconds(0.8f);
        isDamaged = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isDamaged)
        {
            if (other.tag == "HitBox")
            {
                Debug.Log("Player KnockBack");
                damaged_pos = other.transform.position;
                StartCoroutine(Knock_Back(150.0f));
            }
        }
    }

}
