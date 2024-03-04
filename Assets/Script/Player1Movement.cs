using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    public float speed = 5.0f;
    public float sprint = 10.0f;
    public float currentSpeed;
    public float jumpForce = 250f;
    public float rotationspeed = 100.0f;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;
    bool isGrounded = false;

    public Vector3 positionBaseP1 = new Vector3(10, 1, 0);
    public Quaternion rotationBaseP1 = Quaternion.Euler(0f, -90f, 0f);
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("HorizontalPlayer1");
        forwardInput = Input.GetAxis("VerticalPlayer1");

        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime * forwardInput);
        transform.Rotate((transform.up * horizontalInput) * rotationspeed * Time.deltaTime);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.LeftShift) && StaminaBarPlayer1.P1.currentStamina > 1)
        {
            StaminaBarPlayer1.P1.UseStamina(0.1f);
            Sprint();
        }
        else
            currentSpeed = speed;
    }

    private void Sprint()
    {
        currentSpeed = sprint;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
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
