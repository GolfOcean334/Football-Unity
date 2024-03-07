using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public float speed = 5.0f;
    public float sprint = 10.0f;
    public float currentSpeed;
    public float jumpForce = 250f;

    public float jetpackAcceleration = 10f;
    public float maxJetpackForce = 100f;
    private float currentJetpackForce = 0f;
    private float maxVerticalVelocity = 5f;

    public Camera playerCam;
    public float sprintFOV = 65f;
    public float defaultFOV = 60f;
    public float fovChangeSpeed = 5f;

    public float rotationspeed = 100.0f;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;
    bool isGrounded = false;


    public Vector3 positionBaseP2 = new Vector3(-10, 1, 0);
    public Quaternion rotationBaseP2 = Quaternion.Euler(0f, 90f, 0f);
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
            Jump();
        }

        if (Input.GetKey(KeyCode.Keypad0) && StaminaBarPlayer2.P2.currentStamina > 1 && Input.GetKey(KeyCode.UpArrow))
        {
            StaminaBarPlayer2.P2.UseStamina(0.1f);
            Sprint();
            playerCam.fieldOfView = Mathf.Lerp(playerCam.fieldOfView, sprintFOV, Time.deltaTime * fovChangeSpeed);
        }
        else
        {
            currentSpeed = speed;
            playerCam.fieldOfView = Mathf.Lerp(playerCam.fieldOfView, defaultFOV, Time.deltaTime * fovChangeSpeed);
        }

    
        if (Input.GetKey(KeyCode.RightControl) && FuelBarP2.P2.currentFuel > 1)
        {
            // Increment the jetpack force up to the maximum value
            if (currentJetpackForce < maxJetpackForce)
            {
                currentJetpackForce += jetpackAcceleration * Time.deltaTime;
                currentJetpackForce = Mathf.Clamp(currentJetpackForce, 0f, maxJetpackForce);
            }

            // Apply the jetpack force smoothly
            playerRb.AddForce(Vector3.up * currentJetpackForce, ForceMode.Acceleration);
            FuelBarP2.P2.UseFuel(0.1f);

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

    public void PositionBaseP2(Vector3 position)
    {
        transform.position = position;
    }

    public void RotationBaseP2()
    {
        transform.rotation = rotationBaseP2;
    }
}
