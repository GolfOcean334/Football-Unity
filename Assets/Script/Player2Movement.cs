using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Player2Movement : MonoBehaviour
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


    public Vector3 positionBaseP2 = new Vector3(10, 1, 0);
    public Quaternion rotationBaseP2 = Quaternion.Euler(0f, -90f, 0f);
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("HorizontalPlayer2");
        forwardInput = Input.GetAxis("VerticalPlayer2");

        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime * forwardInput);
        transform.Rotate((transform.up * horizontalInput) * rotationspeed * Time.deltaTime);

        if (isGrounded && Input.GetKeyDown(KeyCode.RightControl))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.Keypad0) && StaminaBarPlayer2.P2.currentStamina > 1)
        {
            StaminaBarPlayer2.P2.UseStamina(0.1f);
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

    public void PositionBaseP2(Vector3 position)
    {
        transform.position = position;
    }

    public void RotationBaseP2()
    {
        transform.rotation = rotationBaseP2;
    }
}
