using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_ChatacterMovement : MonoBehaviour
{
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
        
    }

    private void Update()
    {
        RaycastHit hit;
        Direction = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

        if (Direction.sqrMagnitude > 0.01f)
        {
            transform.forward = Direction;
            if (!Physics.CapsuleCast(transform.position + Vector3.up * 0.7f, transform.position + Vector3.up * 2, 0.3f, Direction, 0.1f))
                transform.position += Direction * Speed * Time.deltaTime;
        }

        if (Physics.Raycast(transform.position + Vector3.up, Vector3.down, out hit, 1.0f))
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
}
