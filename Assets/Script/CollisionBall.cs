using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TriggerBall : MonoBehaviour
{
    private PositionBall positionBall;
    private MovePlayer1 positionP1;
    private MovePlayer1 rotationP1;
    private MovePlayer2 positionP2;
    private MovePlayer2 rotationP2;
    private PositionBall rotationBall;
    private Rigidbody ballRigidbody;

    private scoreBlueteam winBlueteam;
    private scoreRedteam winRedteam;

    private bool isBallTouched = false;

    void Start()
    {
        positionBall = FindObjectOfType<PositionBall>();
        rotationBall = FindObjectOfType<PositionBall>();
        positionP1 = FindObjectOfType<MovePlayer1>();
        rotationP1 = FindObjectOfType<MovePlayer1>();
        positionP2 = FindObjectOfType<MovePlayer2>();
        rotationP2 = FindObjectOfType<MovePlayer2>();
        ballRigidbody = GetComponent<Rigidbody>();

        winBlueteam = FindObjectOfType<scoreBlueteam>();
        winRedteam = FindObjectOfType<scoreRedteam>();
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

            ballRigidbody.velocity = Vector3.zero;
            ballRigidbody.angularVelocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isBallTouched = false;
        }

        if ((collision.gameObject.CompareTag("RedPlayer") || collision.gameObject.CompareTag("BluePlayer")) && !isBallTouched)
        {
            float throwForce = 0f;

            if (collision.gameObject.CompareTag("RedPlayer"))
            {
                throwForce = collision.gameObject.GetComponent<MovePlayer1>().speed;
            }
            else if (collision.gameObject.CompareTag("BluePlayer"))
            {
                throwForce = collision.gameObject.GetComponent<MovePlayer2>().speed;
            }

            Vector3 direction = collision.transform.position - transform.position;

            float arcHeight = 0.05f;

            Vector3 newVelocity = new Vector3(direction.x, Mathf.Sqrt(arcHeight * (throwForce * 3)), direction.z);
            ballRigidbody.velocity = newVelocity;
            isBallTouched = true;
        }
    }
}
