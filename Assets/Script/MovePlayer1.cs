using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovePlayer1 : MonoBehaviour
{
    public float speed = 200f;
    public float rotationspeed = 100f;
    public float sprint = 800f;
    public float jumpForce = 5f;
    public float gravityMultiplier = 100f;

    public Vector3 positionBaseP1 = new Vector3(10, 1, 0);
    public Quaternion rotationBaseP1 = Quaternion.Euler(0f, -90f, 0f);

    private Rigidbody _rigidbody;
    bool isGrounded = false;

    public Camera playerCamera;

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

            if (playerCamera != null)
            {
                float cameraMoveSpeed = 0.01f * speed * Time.deltaTime;
                playerCamera.transform.Translate(Vector3.back * cameraMoveSpeed);
            }
        }
        else
        {
            speed = 400f;
        }

        _rigidbody.velocity = (transform.forward * vAxis) * speed * Time.deltaTime;
        transform.Rotate((transform.up * hAxis) * rotationspeed * Time.deltaTime);

        _rigidbody.AddForce(Vector3.down * gravityMultiplier * _rigidbody.mass);
    }

    private void Update()
    {
        Jump();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Touche le sol");
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Touche le sol");
            isGrounded = false;
        }
    }

    private void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.up * jumpForce * 10f, ForceMode.Force);
            Debug.Log("Jump");
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
