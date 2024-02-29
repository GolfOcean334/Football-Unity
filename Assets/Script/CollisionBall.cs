using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBall : MonoBehaviour
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
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Bluescored")
        {
            scoreBlueteam.scorecount += 1;
            positionBall.PositionBaseBall(positionBall.positionBase);
            positionP1.PositionBaseP1(positionP1.positionBaseP1);
            positionP2.PositionBaseP2(positionP2.positionBaseP2);

        }

        if (other.gameObject.tag == "Redscored")
        {
            scoreRedteam.scorecount += 1;
            positionBall.PositionBaseBall(positionBall.positionBase);
            positionP1.PositionBaseP1(positionP1.positionBaseP1);
            positionP2.PositionBaseP2(positionP2.positionBaseP2);
        }
    }
}
