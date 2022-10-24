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


    [SerializeField, Header("�̵�")]
    private float _speed = 10;
    [SerializeField]
    private float _maxGravitySpeed = 10.0f;
    [SerializeField]
    private float _gravityAccel = 0.0981f;

 private float _gravitySpeed = 0.0f;
    private Vector3 _direction = Vector3.zero;
    private Vector3 _centerPos=Vector3.zero;
    private float _height = 0.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _centerPos = GetComponent<Collider>().bounds.center - transform.position;
        _height = GetComponent<Collider>().bounds.extents.y;

    }

    private void Update()
    {
        RaycastHit hit;
        if (!isDamaged)
        {
            _direction = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

            if (_direction.sqrMagnitude > 0.01f)
            {
                transform.forward = _direction;
                if (!Physics.CapsuleCast(
                    transform.position + _centerPos * 0.7f
                    , transform.position + _centerPos * 2
                    , 0.3f
                    , _direction
                    , 0.1f))
                    transform.position += _direction * _speed * Time.deltaTime;
            }

            if (Physics.Raycast(transform.position + _centerPos, Vector3.down, out hit, _height))
            {
                _gravitySpeed = 0;
                transform.position += new Vector3(0, _height - hit.distance, 0);
            }
            else
            {
                if (_gravitySpeed < _maxGravitySpeed)
                    _gravitySpeed += _gravityAccel;
                transform.position += new Vector3(0, -_gravitySpeed, 0) * Time.deltaTime;
            }
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
