using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))]
public class MovePlayer1 : MonoBehaviour
{
    public float speed = 200f;
    public float rotationspeed = 100f;
    public float sprint = 800f;
    public float jumpForce = 50f;
    public float gravityMultiplier = 100f;

    public Vector3 positionBaseP1 = new Vector3(10, 1, 0);
    public Quaternion rotationBaseP1 = Quaternion.Euler(0f, -90f, 0f);

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.mass = 1f;
    }

    private void FixedUpdate()
    {
        float hAxis = Input.GetAxis("HorizontalPlayer1");
        float vAxis = Input.GetAxis("VerticalPlayer1");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprint;
        }
        else
        {
            speed = 400f;
        }

        _rigidbody.velocity = (transform.forward * vAxis) * speed * Time.deltaTime;
        transform.Rotate((transform.up * hAxis) * rotationspeed * Time.deltaTime);

        // Appliquer la gravité avec le coefficient approprié
        _rigidbody.AddForce(Vector3.down * gravityMultiplier * _rigidbody.mass);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Touche le sol");
            if (Input.GetKeyUp(KeyCode.Space))
            {
                _rigidbody.AddForce(Vector3.up * jumpForce * 100f);
                Debug.Log("Je saute");
            }
        }
    }

    public void PositionBaseP1(Vector3 position)
    {
        transform.position = position;
    }

    public void RotationBaseP1()
    {
        transform.rotation = rotationBaseP1;
    }
}
