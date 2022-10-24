using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_CharacterMovement : MonoBehaviour
{
    [SerializeField, Header("¿Ãµø")]
    private float _speed = 10;
    [SerializeField]
    private float _gravityAccel = 0.0981f;
    [SerializeField]
    private float _maxGravitySpeed = 10.0f;

    private float _gravitySpeed = 0.0f;
    private Vector3 _direction = Vector3.zero;
    private Vector3 _centerPos = Vector3.zero;
    private float _height = 0.0f;

    private P_CameraMovement _camera = null;
    //private P_Enemy _enemy = null;


    private void Start()
    {
        _centerPos = GetComponent<Collider>().bounds.center - transform.position;
        _height = GetComponent<Collider>().bounds.extents.y;
    }

    private void Update()
    {
        RaycastHit hit;
        _direction = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

        if (_direction.sqrMagnitude > 0.01f)
        {
            transform.forward = _direction;
            if (!Physics.CapsuleCast(transform.position + _centerPos * 0.7f, transform.position + _centerPos * 2, 0.3f, _direction, 0.1f))
                transform.position += _direction * _speed * Time.deltaTime;
        }

        if (Physics.Raycast(transform.position + _centerPos, Vector3.down, out hit, _height))
        {
            _gravitySpeed = 0;
            transform.position += new Vector3(0, 1 - hit.distance, 0);
        }
        else
        {
            if (_gravitySpeed < _maxGravitySpeed)
                _gravitySpeed += _gravityAccel;
            transform.position += new Vector3(0, -_gravitySpeed, 0) * Time.deltaTime;
        }
    }



    public void RegisterCamera(P_CameraMovement camera)
    {
        _camera = camera;
    }

    //public void RegisterEnemy(P_Enemy enemy)
    //{
    //    _enemy = enemy;
    //    _camera.SwitchBattleMode();

    //}
    //public void UnResterEnemy()
    //{
    //    _enemy = null;
    //    _camera.SwitchIdleMode();
    //}
}
