using UnityEngine;

public class Ball : MonoBehaviour
{
    private PositionBall positionBall;
    private Player1Movement positionP1;
    private Player1Movement rotationP1;
    private Player2Movement positionP2;
    private Player2Movement rotationP2;
    private PositionBall rotationBall;
    private Rigidbody ballRigidbody;

    private StaminaBarPlayer1 staminaP1;
    private StaminaBarPlayer2 staminaP2;

    private scoreBlueteam winBlueteam;
    private scoreRedteam winRedteam;

    private AudioSource audioSource;

    private bool isBallTouched = false;

    public ParticleSystem ballParticles;

    void Start()
    {
        positionBall = FindObjectOfType<PositionBall>();
        rotationBall = FindObjectOfType<PositionBall>();
        positionP1 = FindObjectOfType<Player1Movement>();
        rotationP1 = FindObjectOfType<Player1Movement>();
        positionP2 = FindObjectOfType<Player2Movement>();
        rotationP2 = FindObjectOfType<Player2Movement>();
        ballRigidbody = GetComponent<Rigidbody>();
        staminaP1 = FindObjectOfType<StaminaBarPlayer1>();
        staminaP2 = FindObjectOfType<StaminaBarPlayer2>();
        winBlueteam = FindObjectOfType<scoreBlueteam>();
        winRedteam = FindObjectOfType<scoreRedteam>();
        audioSource = GetComponent<AudioSource>();

        positionBall.PositionBaseBall(positionBall.positionBase);
        rotationBall.RotationBaseBall();
        positionP1.PositionBaseP1(positionP1.positionBaseP1);
        rotationP1.RotationBaseP1();
        positionP2.PositionBaseP2(positionP2.positionBaseP2);
        rotationP2.RotationBaseP2();

        staminaP1.GetStaminaP1();
        staminaP2.GetStaminaP2();

        ballRigidbody.velocity = Vector3.zero;
        ballRigidbody.angularVelocity = Vector3.zero;

        ballParticles = GetComponentInChildren<ParticleSystem>(); // Assurez-vous d'avoir un Particle System attaché à la balle ou à un de ses enfants
        if (ballParticles != null)
        {
            ballParticles.Stop(); // Assurez-vous que le système de particules est initialisé en mode arrêté
        }
    }

    private void Update()
    {
        winRedteam.WinRedTeam();
        winBlueteam.WinBlueTeam();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bluescored") || other.gameObject.CompareTag("Redscored"))
        {
            if (other.gameObject.CompareTag("Bluescored"))
                scoreBlueteam.scorecount += 1;
                
            else
                scoreRedteam.scorecount += 1;

            positionBall.PositionBaseBall(positionBall.positionBase);
            rotationBall.RotationBaseBall();
            positionP1.PositionBaseP1(positionP1.positionBaseP1);
            rotationP1.RotationBaseP1();
            positionP2.PositionBaseP2(positionP2.positionBaseP2);
            rotationP2.RotationBaseP2();

            staminaP1.GetStaminaP1();
            staminaP2.GetStaminaP2();

            ballRigidbody.velocity = Vector3.zero;
            ballRigidbody.angularVelocity = Vector3.zero;

            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isBallTouched = false;
            if (ballParticles != null)
            {
                ballParticles.Stop();
            }
        }

        if ((collision.gameObject.CompareTag("RedPlayer") || collision.gameObject.CompareTag("BluePlayer")) && !isBallTouched)
        {
            float throwForce = 0f;

            if (collision.gameObject.CompareTag("RedPlayer"))
            {
                throwForce = collision.gameObject.GetComponent<Player1Movement>().currentSpeed;
            }
            else if (collision.gameObject.CompareTag("BluePlayer"))
            {
                throwForce = collision.gameObject.GetComponent<Player2Movement>().currentSpeed;
            }

            Vector3 direction = collision.transform.forward;

            float arcHeight = 0.5f;
            float multiplicator = 10f;

            Vector3 forceDirection = new Vector3((direction.x * multiplicator), Mathf.Sqrt(arcHeight * (throwForce * 3) * (multiplicator / 2)), (direction.z * multiplicator));

            ballRigidbody.AddForce(forceDirection, ForceMode.Impulse);

            isBallTouched = true;

            if (ballParticles != null)
            {
                //ballParticles.velocityOverLifetime = Vector3(direction.x, 0, direction.y);
                ballParticles.Play();
            }

            isBallTouched = true;
        }
    }
}