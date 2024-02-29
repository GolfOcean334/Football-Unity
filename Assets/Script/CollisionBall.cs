using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TriggerBall : MonoBehaviour
{
    private PositionBall positionBall;
    private MovePlayer1 positionP1;
    private MovePlayer2 positionP2;

    void Start()
    {
        positionBall = FindObjectOfType<PositionBall>();
        positionP1 = FindObjectOfType<MovePlayer1>();
        positionP2 = FindObjectOfType<MovePlayer2>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bluescored"))
        {
            scoreBlueteam.scorecount += 1;
            positionBall.PositionBaseBall(positionBall.positionBase);
            positionP1.PositionBaseP1(positionP1.positionBaseP1);
            positionP2.PositionBaseP2(positionP2.positionBaseP2);
        }

        if (other.gameObject.CompareTag("Redscored"))
        {
            scoreRedteam.scorecount += 1;
            positionBall.PositionBaseBall(positionBall.positionBase);
            positionP1.PositionBaseP1(positionP1.positionBaseP1);
            positionP2.PositionBaseP2(positionP2.positionBaseP2);
        }
    }
}
