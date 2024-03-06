using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    public float speed = 5.0f;
    public float sprint = 10.0f;
    public float currentSpeed;
    public float jumpForce = 250f;
    public float rotationspeed = 100.0f;

    public float jetpackAcceleration = 10f;
    public float maxJetpackForce = 100f;
    private float currentJetpackForce = 0f;
    private float maxVerticalVelocity = 5f;

    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;
    private bool isGrounded = false;
    private bool isJumping = false;

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
            isJumping = true;
            Jump();
        }

        if (isJumping && Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
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

        if (Input.GetKey(KeyCode.Space) && FuelBarP1.P1.currentFuel > 1)
        {
            // Increment the jetpack force up to the maximum value
            if (currentJetpackForce < maxJetpackForce)
            {
                currentJetpackForce += jetpackAcceleration * Time.deltaTime;
                currentJetpackForce = Mathf.Clamp(currentJetpackForce, 0f, maxJetpackForce);
            }

            // Apply the jetpack force smoothly
            playerRb.AddForce(Vector3.up * currentJetpackForce, ForceMode.Acceleration);
            FuelBarP1.P1.UseFuel(0.1f);

            // Clamp the velocity to limit the upward speed
            playerRb.velocity = Vector3.ClampMagnitude(playerRb.velocity, maxVerticalVelocity);
        }
        else
        {
            // Reset the current jetpack force when not using the jetpack
            currentJetpackForce = 0f;
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
