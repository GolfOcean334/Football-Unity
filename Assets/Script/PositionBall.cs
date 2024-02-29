using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionBall : MonoBehaviour
{
    public Vector3 positionBase = new Vector3(0, 1, 0);
    void Start()
    {
        PositionBaseBall(positionBase);
    }

    
    void Update()
    {
        
    }

    public void PositionBaseBall(Vector3 position)
    {
        transform.position = position;
    }
}
