using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBall : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Bluescored")
        {
            scoreBlueteam.scorecount += 1;
        }

        if (other.gameObject.tag == "Redscored")
        {
            scoreRedteam.scorecount += 1;
        }

        if (other.gameObject.tag == "RedPlayer")
        {
            Debug.Log("Joueur touche la balle");
        }
    }
}
