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

    void Start()
    {
        positionBall = FindObjectOfType<PositionBall>();
        rotationBall = FindObjectOfType<PositionBall>();
        positionP1 = FindObjectOfType<MovePlayer1>();
        rotationP1 = FindObjectOfType<MovePlayer1>();
        positionP2 = FindObjectOfType<MovePlayer2>();
        rotationP2 = FindObjectOfType<MovePlayer2>();
        ballRigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bluescored") || other.gameObject.CompareTag("Redscored"))
        {
            // Increment the score
            if (other.gameObject.CompareTag("Bluescored"))
                scoreBlueteam.scorecount += 1;
            else
                scoreRedteam.scorecount += 1;

            // Reset the positions and rotations
            positionBall.PositionBaseBall(positionBall.positionBase);
            rotationBall.RotationBaseBall();
            positionP1.PositionBaseP1(positionP1.positionBaseP1);
            rotationP1.RotationBaseP1();
            positionP2.PositionBaseP2(positionP2.positionBaseP2);
            rotationP2.RotationBaseP2();

            // Reset the Rigidbody properties to remove inertia
            ballRigidbody.velocity = Vector3.zero;
            ballRigidbody.angularVelocity = Vector3.zero;
        }
    }
}
