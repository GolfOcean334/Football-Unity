using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBall : MonoBehaviour
{
    void Start()
    {

    }
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collisionBall)
    {
        
        if (collisionBall.gameObject.name == "Ball")
        {
            Debug.Log("Touch� par " + collisionBall.gameObject.name);
        }
    }
}
