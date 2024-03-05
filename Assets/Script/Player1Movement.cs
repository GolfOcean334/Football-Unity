using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
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

    void Update()
    {
        horizontalInput = Input.GetAxis("HorizontalPlayer1");
        forwardInput = Input.GetAxis("VerticalPlayer1");

        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime * forwardInput);
        transform.Rotate((transform.up * horizontalInput) * rotationspeed * Time.deltaTime);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.LeftShift) && StaminaBarPlayer1.P1.currentStamina > 1 && Input.GetKey(KeyCode.W))
        {
            StaminaBarPlayer1.P1.UseStamina(0.1f);
            Sprint();
        }
        else
        {
            currentSpeed = speed;
        }

        if(Input.GetKey(KeyCode.Space) && FuelBarP1.P1.currentFuel > 1)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            FuelBarP1.P1.UseFuel(0.1f);

            if(playerRb.velocity.magnitude > 1)
            {
                playerRb.velocity = Vector3.ClampMagnitude(playerRb.velocity, 1);
            }
        }
    }

    private void Sprint()
    {
        currentSpeed = sprint;
    }

    private void Jump()
    {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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
