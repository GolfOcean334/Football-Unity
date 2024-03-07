using System;
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
    public ParticleSystem goalRedParticles;
    public ParticleSystem goalBlueParticles;

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
        ballParticles = GetComponentInChildren<ParticleSystem>();
        if (ballParticles != null)
        {
            ballParticles.Stop();
        }
        if (goalRedParticles != null)
        {
            goalRedParticles.Stop();
        }
        if (goalBlueParticles != null)
        {
            goalBlueParticles.Stop();
        }

        // Initialisation de toutes les entitées
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
            {
                scoreBlueteam.scorecount += 1;
                goalRedParticles.Play();
            }
            else
            {
                scoreRedteam.scorecount += 1;
                goalBlueParticles.Play();
            }
            
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
            ballParticles.Stop();
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

            //Direction des particules en fonctions de la direction de la frappe du joueur
            var velocityOverLifetime = ballParticles.velocityOverLifetime;
            velocityOverLifetime.x = -direction.x;
            velocityOverLifetime.y = 0;
            velocityOverLifetime.z = -direction.z;
            ballParticles.Play();
            isBallTouched = true;
        }
    }
}