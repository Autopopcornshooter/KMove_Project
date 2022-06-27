using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    Rigidbody rgd;
    Vector3 move_dir;
    // Start is called before the first frame update
    void Start()
    {
        rgd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        move_dir.x = Input.GetAxis("Horizontal");
        rgd.
    }
}
