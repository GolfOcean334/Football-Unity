using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBalle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Touché par " + collision.gameObject.name);
    }
}
