using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_CameraMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject _character = null;

    [SerializeField]
    private Vector3 _offset = new Vector3(0, 2.5f, -3);
    [SerializeField]
    private Quaternion _direction = new Quaternion(50, 0, 0, 0);
    [SerializeField]
    private float _delay = 20;
    
    
    private void Start()
    {
        
    }

    private void LateUpdate()
    {
        if (_character)
        {
            transform.position = Vector3.Lerp(transform.position, _character.transform.position + _offset, _delay * Time.deltaTime);
        }
    }
}
